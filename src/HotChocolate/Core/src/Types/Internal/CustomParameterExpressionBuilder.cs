using System;
using System.Linq.Expressions;
using System.Reflection;
using HotChocolate.Resolvers;
using HotChocolate.Resolvers.Expressions;

#nullable enable

namespace HotChocolate.Internal
{
    /// <summary>
    /// A custom parameter expression builder allows to implement custom resolver parameter
    /// injection logic.
    /// </summary>
    public abstract class CustomParameterExpressionBuilder : IParameterExpressionBuilder
    {
        ArgumentKind IParameterExpressionBuilder.Kind => ArgumentKind.Custom;

        bool IParameterExpressionBuilder.IsPure => false;

        /// <summary>
        /// Checks if this expression builder can handle the following parameter.
        /// </summary>
        /// <param name="parameter">
        /// The parameter that needs to be resolved.
        /// </param>
        /// <param name="source">
        /// The runtime type of the object that is being resolved.
        /// </param>
        /// <returns>
        /// <c>true</c> if the parameter can be handled by this expression builder;
        /// otherwise <c>false</c>.
        /// </returns>
        public abstract bool CanHandle(ParameterInfo parameter, Type source);

        /// <summary>
        /// Builds an expression that resolves a resolver parameter.
        /// </summary>
        /// <param name="parameter">
        /// The parameter that needs to be resolved.
        /// </param>
        /// <param name="source">
        /// The runtime type of the object that is being resolved.
        /// </param>
        /// <param name="context">
        /// An expression that represents the resolver context.
        /// </param>
        /// <returns>
        /// Returns an expression that resolves the value for this <paramref name="parameter"/>.
        /// </returns>
        public abstract Expression Build(ParameterInfo parameter, Type source, Expression context);
    }

    /// <summary>
    /// A custom parameter expression builder that allows to specify the expressions by
    /// passing them into the constructor.
    /// </summary>
    public sealed class CustomParameterExpressionBuilder<TArg> : CustomParameterExpressionBuilder
    {
        private readonly Func<ParameterInfo, bool> _canHandle;
        private readonly Expression<Func<IResolverContext, TArg>> _expression;

        /// <summary>
        /// Initializes a new instance of <see cref="CustomParameterExpressionBuilder"/>.
        /// </summary>
        /// <param name="expression">
        /// The expression that shall be used to resolve the parameter value.
        /// </param>
        public CustomParameterExpressionBuilder(
            Expression<Func<IResolverContext, TArg>> expression)
        {
            _canHandle = p => p.ParameterType == typeof(TArg);
            _expression = expression;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CustomParameterExpressionBuilder"/>.
        /// </summary>
        /// <param name="canHandle">
        /// A func that defines if a parameter can be handled by this expression builder.
        /// </param>
        /// <param name="expression">
        /// The expression that shall be used to resolve the parameter value.
        /// </param>
        public CustomParameterExpressionBuilder(
            Func<ParameterInfo, bool> canHandle,
            Expression<Func<IResolverContext, TArg>> expression)
        {
            _canHandle = canHandle;
            _expression = expression;
        }

        public override bool CanHandle(ParameterInfo parameter, Type source)
            => _canHandle(parameter);

        public override Expression Build(ParameterInfo parameter, Type source, Expression context)
            => Expression.Invoke(_expression, context);
    }
}
