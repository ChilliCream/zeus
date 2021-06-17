using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate.Properties;
using HotChocolate.Resolvers.CodeGeneration;
using HotChocolate.Utilities;

#nullable enable

namespace HotChocolate.Resolvers.Expressions
{
    public sealed class ResolveCompiler : ResolverCompiler
    {
        private static readonly MethodInfo _awaitTaskHelper =
            typeof(ExpressionHelper).GetMethod(nameof(ExpressionHelper.AwaitTaskHelper))!;
        private static readonly MethodInfo _awaitValueTaskHelper =
            typeof(ExpressionHelper).GetMethod(nameof(ExpressionHelper.AwaitValueTaskHelper))!;
        private static readonly MethodInfo _wrapResultHelper =
            typeof(ExpressionHelper).GetMethod(nameof(ExpressionHelper.WrapResultHelper))!;

        internal FieldResolver Compile(ResolverDescriptor descriptor)
        {
            if (descriptor.Field.Member is not null)
            {
                FieldResolverDelegate resolver;
                PureFieldResolverDelegate? pureResolver = null;
                InlineFieldDelegate? inlineResolver = null;

                if (descriptor.Field.Member is MethodInfo { IsStatic: true })
                {
                    resolver = CreateResolver(
                        descriptor.Field.Member,
                        descriptor.SourceType);
                }
                else
                {
                    Expression resolverInstance = CreateResolverInstance(
                        descriptor.SourceType,
                        descriptor.ResolverType);

                    resolver = CreateResolver(
                        resolverInstance,
                        descriptor.Field.Member,
                        descriptor.SourceType);

                    pureResolver = CreatePureResolver(
                        resolverInstance,
                        descriptor.Field.Member,
                        descriptor.SourceType,
                        descriptor.ResolverType ?? descriptor.SourceType);
                }

                if (descriptor.Field.Member is PropertyInfo property &&
                    (descriptor.SourceType == descriptor.ResolverType ||
                        descriptor.ResolverType is null) &&
                    IsPureResult(property.PropertyType))
                {
                    inlineResolver = CreateInlineResolver(descriptor.SourceType, property);
                }

                return new FieldResolver(
                    descriptor.Field.TypeName,
                    descriptor.Field.FieldName,
                    resolver,
                    pureResolver,
                    inlineResolver);
            }

            if (descriptor.Field.Expression is LambdaExpression lambda)
            {
                var resolver = Expression.Lambda<FieldResolverDelegate>(
                    HandleResult(
                        Expression.Invoke(lambda, CreateResolverInstance(
                            descriptor.SourceType,
                            descriptor.ResolverType)),
                        lambda.ReturnType),
                    Context);

                return new FieldResolver(
                    descriptor.Field.TypeName,
                    descriptor.Field.FieldName,
                    resolver.Compile());
            }

            throw new NotSupportedException();
        }

        public FieldResolverDelegates Compile(
            Type sourceType,
            MemberInfo member,
            Type? resolverType = null)
        {
            FieldResolverDelegate resolver;
            PureFieldResolverDelegate? pureResolver = null;
            InlineFieldDelegate? inlineResolver = null;

            if (member is MethodInfo { IsStatic: true })
            {
                resolver = CreateResolver(member, sourceType);
            }
            else
            {
                Expression resolverInstance = CreateResolverInstance(sourceType, resolverType);

                resolver = CreateResolver(resolverInstance, member, sourceType);

                pureResolver = CreatePureResolver(
                    resolverInstance,
                    member,
                    sourceType,
                    resolverType ?? sourceType);
            }

            if (member is PropertyInfo property &&
                (sourceType == resolverType || resolverType is null) &&
                IsPureResult(property.PropertyType))
            {
                inlineResolver = CreateInlineResolver(sourceType, property);
            }

            return new(resolver, pureResolver, inlineResolver);
        }

        public FieldResolverDelegates Compile<TResolver>(
            Expression<Func<TResolver, object?>> propertyOrMethod,
            Type? sourceType = null)
        {
            if (propertyOrMethod is null)
            {
                throw new ArgumentNullException(nameof(propertyOrMethod));
            }

            MemberInfo member = propertyOrMethod.TryExtractMember();

            if (member is PropertyInfo or MethodInfo)
            {
                Type source = sourceType ?? typeof(TResolver);
                Type? resolver = sourceType is null ? typeof(TResolver) : null;
                return Compile(source, member, resolver);
            }

            throw new ArgumentException(
                TypeResources.ObjectTypeDescriptor_MustBePropertyOrMethod,
                nameof(member));
        }

        private Expression CreateResolverInstance(Type sourceType, Type? resolverType = null)
        {
            MethodInfo resolverMethod = resolverType is null
                ? Parent.MakeGenericMethod(sourceType)
                : Resolver.MakeGenericMethod(resolverType);

            return Expression.Call(Context, resolverMethod);
        }

        private FieldResolverDelegate CreateResolver(
            MemberInfo member,
            Type sourceType)
        {
            if (member is MethodInfo method)
            {
                IEnumerable<Expression> parameters =
                    CreateParameters(method.GetParameters(), sourceType);
                MethodCallExpression resolverExpression = Expression.Call(method, parameters);
                Expression handleResult = HandleResult(resolverExpression, method.ReturnType);
                return Expression.Lambda<FieldResolverDelegate>(handleResult, Context).Compile();
            }

            throw new NotSupportedException();
        }

        private FieldResolverDelegate CreateResolver(
            Expression resolverInstance,
            MemberInfo member,
            Type sourceType)
        {
            if (member is MethodInfo method)
            {
                IEnumerable<Expression> parameters = CreateParameters(
                    method.GetParameters(), sourceType);
                MethodCallExpression resolverExpression =
                    Expression.Call(resolverInstance, method, parameters);
                Expression handleResult = HandleResult(resolverExpression, method.ReturnType);
                return Expression.Lambda<FieldResolverDelegate>(handleResult, Context).Compile();
            }

            if (member is PropertyInfo property)
            {
                MemberExpression propertyAccessor = Expression.Property(resolverInstance, property);
                Expression handleResult = HandleResult(propertyAccessor, property.PropertyType);
                return Expression.Lambda<FieldResolverDelegate>(handleResult, Context).Compile();
            }

            throw new NotSupportedException();
        }

        private PureFieldResolverDelegate? CreatePureResolver(
            Expression resolverInstance,
            MemberInfo member,
            Type sourceType,
            Type resolverType)
        {
            if (member is PropertyInfo property && IsPureResult(property.PropertyType))
            {
                MemberExpression propertyAccessor = Expression.Property(resolverInstance, property);
                Expression result = Expression.Convert(propertyAccessor, typeof(object));
                return Expression.Lambda<PureFieldResolverDelegate>(result, Context).Compile();
            }

            if (member is MethodInfo method &&
                IsPureMethod(method, resolverType) &&
                IsPureResult(method.ReturnType) &&
                method.GetParameters().All(p => ArgumentHelper.IsPure(p, sourceType)))
            {
                IEnumerable<Expression> parameters =
                    CreateParameters(method.GetParameters(), sourceType);
                MethodCallExpression resolverCall =
                    Expression.Call(resolverInstance, method, parameters);
                Expression result = Expression.Convert(resolverCall, typeof(object));
                return Expression.Lambda<PureFieldResolverDelegate>(result, Context).Compile();
            }

            return null;
        }

        private static InlineFieldDelegate CreateInlineResolver(
            Type sourceType,
            PropertyInfo property)
        {
            const string parent = nameof(parent);
            ParameterExpression parentParam = Expression.Parameter(typeof(object), parent);
            Expression castParent = Expression.Convert(parentParam, sourceType);
            MemberExpression propertyAccessor = Expression.Property(castParent, property);
            Expression result = Expression.Convert(propertyAccessor, typeof(object));
            return Expression.Lambda<InlineFieldDelegate>(result, parentParam).Compile();
        }

        private static Expression HandleResult(
            Expression resolverExpression,
            Type resultType)
        {
            if (resultType == typeof(ValueTask<object>))
            {
                return resolverExpression;
            }

            if (typeof(Task).IsAssignableFrom(resultType) &&
                resultType.IsGenericType)
            {
                return AwaitTaskMethodCall(
                    resolverExpression,
                    resultType.GetGenericArguments()[0]);
            }

            if (resultType.IsGenericType
                && resultType.GetGenericTypeDefinition() == typeof(ValueTask<>))
            {
                return AwaitValueTaskMethodCall(
                    resolverExpression,
                    resultType.GetGenericArguments()[0]);
            }

            return WrapResult(resolverExpression, resultType);
        }

        private static bool IsPureMethod(MethodInfo methodInfo, Type resolverType)
        {
            if (methodInfo.IsDefined(typeof(PureAttribute)))
            {
                return true;
            }

            ConstructorInfo[] constructors = resolverType.GetConstructors();
            if (constructors.Length == 1 && constructors[0].GetParameters().Length == 0)
            {
                return true;
            }

            return false;
        }

        private static bool IsPureResult(Type resultType)
        {
            if (resultType == typeof(ValueTask<object>))
            {
                return false;
            }

            if (typeof(IExecutable).IsAssignableFrom(resultType) ||
                typeof(IQueryable).IsAssignableFrom(resultType) ||
                typeof(Task).IsAssignableFrom(resultType))
            {
                return false;
            }

            if (resultType.IsGenericType)
            {
                Type type = resultType.GetGenericTypeDefinition();
                if (type == typeof(ValueTask<>) ||
                    type == typeof(IAsyncEnumerable<>))
                {
                    return false;
                }
            }

            return true;
        }

        private static MethodCallExpression AwaitTaskMethodCall(
            Expression taskExpression, Type valueType)
        {
            MethodInfo awaitHelper = _awaitTaskHelper.MakeGenericMethod(valueType);
            return Expression.Call(awaitHelper, taskExpression);
        }

        private static MethodCallExpression AwaitValueTaskMethodCall(
            Expression taskExpression, Type valueType)
        {
            MethodInfo awaitHelper = _awaitValueTaskHelper.MakeGenericMethod(valueType);
            return Expression.Call(awaitHelper, taskExpression);
        }

        private static MethodCallExpression WrapResult(
            Expression taskExpression, Type valueType)
        {
            MethodInfo wrapResultHelper = _wrapResultHelper.MakeGenericMethod(valueType);
            return Expression.Call(wrapResultHelper, taskExpression);
        }
    }
}
