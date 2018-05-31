using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using HotChocolate.Configuration;
using HotChocolate.Internal;
using HotChocolate.Resolvers;

namespace HotChocolate.Types
{
    internal class FieldDescriptor
        : IFieldDescriptor
    {
        private readonly string _typeName;

        public FieldDescriptor(string typeName, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentException(
                    "The field name cannot be null or empty.",
                    nameof(fieldName));
            }

            if (ValidationHelper.IsFieldNameValid(fieldName))
            {
                throw new ArgumentException(
                    "The specified name is not a valid GraphQL field name.",
                    nameof(fieldName));
            }

            _typeName = typeName;
            Name = fieldName;
        }

        public FieldDescriptor(string typeName, PropertyInfo property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            _typeName = typeName;
            Property = property;
            Name = property.GetGraphQLName();
        }

        public FieldDescriptor(PropertyInfo property, string name)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            Property = property;
            Name = name;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public PropertyInfo Property { get; protected set; }

        public Type NativeType { get; protected set; }

        public string DeprecationReason { get; protected set; }

        public ImmutableList<ArgumentDescriptor> Arguments { get; protected set; }
            = ImmutableList<ArgumentDescriptor>.Empty;

        public FieldResolverDelegate Resolver { get; protected set; }

        public Field CreateField()
        {
            return new Field(new FieldConfig
            {
                Name = Name,
                Description = Description,
                DeprecationReason = DeprecationReason,
                Member = Property,
                Type = CreateType,
                NativeNamedType = TypeInspector.Default.ExtractNamedType(NativeType),
                Arguments = CreateArguments(),
                Resolver = CreateResolver
            });
        }

        private IOutputType CreateType(ITypeRegistry typeRegistry)
        {
            return TypeInspector.Default.CreateOutputType(
                typeRegistry, NativeType);
        }

        private IEnumerable<InputField> CreateArguments()
        {
            return Arguments.Select(t => t.CreateArgument());
        }

        private FieldResolverDelegate CreateResolver(
            IResolverRegistry resolverRegistry)
        {
            return Resolver ?? resolverRegistry.GetResolver(_typeName, Name);
        }

        #region IFieldDescriptor

        IFieldDescriptor IFieldDescriptor.Description(string description)
        {
            Description = description;
            return this;
        }

        IFieldDescriptor IFieldDescriptor.Type<TOutputType>()
        {
            NativeType = typeof(TOutputType);
            return this;
        }

        IFieldDescriptor IFieldDescriptor.DeprecationReason(
            string deprecationReason)
        {
            DeprecationReason = deprecationReason;
            return this;
        }

        IFieldDescriptor IFieldDescriptor.Argument(
            string name, Action<IArgumentDescriptor> argument)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "The argument name cannot be null or empty.",
                    nameof(name));
            }

            if (ValidationHelper.IsFieldNameValid(name))
            {
                throw new ArgumentException(
                    "The specified name is not a valid GraphQL argument name.",
                    nameof(name));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argument));
            }

            ArgumentDescriptor descriptor = new ArgumentDescriptor(name);
            Arguments = Arguments.Add(descriptor);
            return this;
        }

        IFieldDescriptor IFieldDescriptor.Resolver(FieldResolverDelegate fieldResolver)
        {
            if (fieldResolver == null)
            {
                throw new ArgumentNullException(nameof(fieldResolver));
            }

            Resolver = fieldResolver;
            return this;
        }

        #endregion
    }
}
