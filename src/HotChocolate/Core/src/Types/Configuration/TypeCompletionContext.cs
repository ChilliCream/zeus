using System.Globalization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace HotChocolate.Configuration
{
    internal sealed class TypeCompletionContext
        : ITypeCompletionContext
    {
        private readonly HashSet<NameString> _alternateNames = new HashSet<NameString>();
        private readonly TypeDiscoveryContext _initializationContext;
        private readonly TypeReferenceResolver _typeReferenceResolver;
        private readonly IDictionary<FieldReference, RegisteredResolver> _resolvers;
        private readonly Func<ISchema> _schemaResolver;

        public TypeCompletionContext(
            TypeDiscoveryContext initializationContext,
            TypeReferenceResolver typeReferenceResolver,
            IList<FieldMiddleware> globalComponents,
            IDictionary<FieldReference, RegisteredResolver> resolvers,
            IsOfTypeFallback isOfType,
            Func<ISchema> schemaResolver)
        {
            _initializationContext = initializationContext ??
                throw new ArgumentNullException(nameof(initializationContext));
            _typeReferenceResolver = typeReferenceResolver ??
                throw new ArgumentNullException(nameof(typeReferenceResolver));
            _resolvers = resolvers ??
                throw new ArgumentNullException(nameof(resolvers));
            IsOfType = isOfType;
            _schemaResolver = schemaResolver ??
                throw new ArgumentNullException(nameof(schemaResolver));
            GlobalComponents = new ReadOnlyCollection<FieldMiddleware>(globalComponents);
            _alternateNames.Add(_initializationContext.InternalName);
        }

        public TypeStatus Status { get; set; } = TypeStatus.Initialized;

        public bool? IsQueryType { get; set; }

        public IReadOnlyList<FieldMiddleware> GlobalComponents { get; }

        public IsOfTypeFallback IsOfType { get; }

        public ITypeSystemObject Type => _initializationContext.Type;

        public string Scope => _initializationContext.Scope;

        public bool IsType => _initializationContext.IsType;

        public bool IsIntrospectionType => _initializationContext.IsIntrospectionType;

        public bool IsDirective => _initializationContext.IsDirective;

        public bool IsSchema => _initializationContext.IsSchema;

        public IServiceProvider Services => _initializationContext.Services;

        public IDictionary<string, object> ContextData => _initializationContext.ContextData;

        public ISet<NameString> AlternateTypeNames => _alternateNames;

        public IDescriptorContext DescriptorContext => _initializationContext.DescriptorContext;

        public ITypeInterceptor TypeInterceptor => _initializationContext.TypeInterceptor;

        public ITypeInspector TypeInspector => _initializationContext.TypeInspector;

        public T GetType<T>(ITypeReference reference)
            where T : IType
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }

            if (!TryGetType(reference, out T type))
            {
                throw new SchemaException(
                    SchemaErrorBuilder.New()
                        .SetMessage(string.Format(
                            CultureInfo.InvariantCulture,
                            "Unable to resolve type directiveRef `{0}`.",
                            reference))
                        .SetTypeSystemObject(Type)
                        .SetExtension(nameof(reference), reference)
                        .Build());
            }
            return type;
        }

        public bool TryGetType<T>(ITypeReference typeRef, out T type)
            where T : IType
        {
            if (Status == TypeStatus.Initialized)
            {
                throw new NotSupportedException();
            }

            if (_typeReferenceResolver.TryGetType(typeRef, out IType t) &&
                t is T casted)
            {
                type = casted;
                return true;
            }

            type = default;
            return false;
        }

        public DirectiveType GetDirectiveType(IDirectiveReference directiveRef)
        {
            if (Status == TypeStatus.Initialized)
            {
                throw new NotSupportedException();
            }

            return _typeReferenceResolver.TryGetDirectiveType(
                directiveRef,
                out DirectiveType directiveType)
                ? directiveType
                : null;
        }

        public FieldResolver GetResolver(NameString fieldName)
        {
            fieldName.EnsureNotEmpty(nameof(fieldName));

            if (Status == TypeStatus.Initialized)
            {
                throw new NotSupportedException();
            }

            if (TryGetResolver(Type.Name, fieldName,
                out FieldResolver resolver))
            {
                return resolver;
            }

            foreach (NameString alternateName in _alternateNames)
            {
                if (TryGetResolver(alternateName, fieldName, out resolver))
                {
                    return resolver;
                }
            }

            return null;
        }

        private bool TryGetResolver(
            NameString typeName,
            NameString fieldName,
            out FieldResolver resolver)
        {
            if (_resolvers.TryGetValue(
                new FieldReference(typeName, fieldName),
                out RegisteredResolver rr)
                && rr.Field is FieldResolver r)
            {
                resolver = r;
                return true;
            }

            resolver = null;
            return false;
        }

        public Func<ISchema> GetSchemaResolver()
        {
            if (Status == TypeStatus.Initialized)
            {
                throw new NotSupportedException();
            }

            return _schemaResolver;
        }

        public IEnumerable<T> GetTypes<T>()
            where T : IType
        {
            if (Status == TypeStatus.Initialized)
            {
                throw new NotSupportedException();
            }

            return _typeReferenceResolver.GetTypes<T>();
        }

        public void ReportError(ISchemaError error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            _initializationContext.ReportError(error);
        }
    }
}
