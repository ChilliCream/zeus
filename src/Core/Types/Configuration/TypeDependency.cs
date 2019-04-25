using System;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Utilities;

namespace HotChocolate.Configuration
{
    public sealed class TypeDependency
    {
        public TypeDependency(ITypeReference typeReference)
            : this(typeReference, TypeDependencyKind.Default)
        {
        }

        public TypeDependency(
            ITypeReference typeReference,
            TypeDependencyKind kind)
        {
            TypeReference = typeReference
                ?? throw new ArgumentNullException(nameof(typeReference));
            Kind = kind;
        }

        public TypeDependencyKind Kind { get; }

        public ITypeReference TypeReference { get; }

        public static TypeDependency FromSchemaType(Type type) =>
            FromSchemaType(type, TypeDependencyKind.Default);

        public static TypeDependency FromSchemaType(
            Type type,
            TypeDependencyKind kind)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (BaseTypes.IsSchemaType(type))
            {
                TypeContext context =
                    SchemaTypeReference.InferTypeContext(type);
                var reference = new ClrTypeReference(type, context);
                return new TypeDependency(reference, kind);
            }

            // TODO : Resources
            throw new ArgumentException("Not a schema type.");
        }
    }
}
