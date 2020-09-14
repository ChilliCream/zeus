﻿using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.Internal;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Pagination;
using static HotChocolate.Utilities.ThrowHelper;
using static HotChocolate.Types.Pagination.Properties.OffsetResources;

namespace HotChocolate.Types
{
    public static class OffsetPagingObjectFieldDescriptorExtensions
    {
        /// <summary>
        /// Applies the offset paging middleware to the current field.
        /// </summary>
        /// <param name="descriptor">
        /// The object field descriptor.
        /// </param>
        /// <param name="itemType">
        /// The item type.
        /// </param>
        /// <param name="resolvePagingProvider">
        /// A delegate allowing to dynamically define a paging resolver for a field.
        /// </param>
        /// <param name="settings">
        /// The paging settings that shall be applied to this field.
        /// </param>
        /// <typeparam name="TSchemaType">
        /// The schema type representation of the item type.
        /// </typeparam>
        /// <returns>
        /// Returns the field descriptor for chaining in other configurations.
        /// </returns>
        public static IObjectFieldDescriptor UseOffsetPaging<TSchemaType>(
            this IObjectFieldDescriptor descriptor,
            Type? itemType = null,
            GetOffsetPagingProvider? resolvePagingProvider = null,
            PagingSettings settings = default)
            where TSchemaType : IOutputType =>
            UseOffsetPaging(
                descriptor, 
                typeof(TSchemaType), 
                itemType, 
                resolvePagingProvider, 
                settings);

        /// <summary>
        /// Applies the offset paging middleware to the current field.
        /// </summary>
        /// <param name="descriptor">
        /// The object field descriptor.
        /// </param>
        /// <param name="type">
        /// The schema type representation of the item type.
        /// </param>
        /// <param name="itemType">
        /// The item type.
        /// </param>
        /// <param name="resolvePagingProvider">
        /// A delegate allowing to dynamically define a paging resolver for a field.
        /// </param>
        /// <param name="settings">
        /// The paging settings that shall be applied to this field.
        /// </param>
        /// <returns>
        /// Returns the field descriptor for chaining in other configurations.
        /// </returns>
        public static IObjectFieldDescriptor UseOffsetPaging(
            this IObjectFieldDescriptor descriptor,
            Type? type = null,
            Type? itemType = null,
            GetOffsetPagingProvider? resolvePagingProvider = null,
            PagingSettings settings = default)
        {
            if (descriptor is null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            resolvePagingProvider ??= ResolvePagingProvider;

            descriptor.AddOffsetPagingArguments();

            PagingHelper.UsePaging(
                descriptor,
                type,
                itemType,
                (services, source) => resolvePagingProvider(services, source),
                settings);

            descriptor
                .Extend()
                .OnBeforeCreate((c, d) => 
                {
                    d.Type = CreateTypeRef(c, d.ResolverMember ?? d.Member, type, settings);
                });

            return descriptor;
        }

        /// <summary>
        /// Applies the offset paging middleware to the current field.
        /// </summary>
        /// <param name="descriptor">
        /// The object field descriptor.
        /// </param>
        /// <param name="settings">
        /// The paging settings that shall be applied to this field.
        /// </param>
        /// <typeparam name="TSchemaType">
        /// The schema type representation of the item type.
        /// </typeparam>
        /// <returns>
        /// Returns the field descriptor for chaining in other configurations.
        /// </returns>
        public static IInterfaceFieldDescriptor UseOffsetPaging<TSchemaType>(
            this IInterfaceFieldDescriptor descriptor,
            PagingSettings settings = default)
            where TSchemaType : class, IOutputType =>
            UseOffsetPaging(descriptor, typeof(TSchemaType), settings);

        /// <summary>
        /// Applies the offset paging middleware to the current field.
        /// </summary>
        /// <param name="descriptor">
        /// The object field descriptor.
        /// </param>
        /// <param name="type">
        /// The schema type representation of the item type.
        /// </param>
        /// <param name="settings">
        /// The paging settings that shall be applied to this field.
        /// </param>
        /// <returns>
        /// Returns the field descriptor for chaining in other configurations.
        /// </returns>
        public static IInterfaceFieldDescriptor UseOffsetPaging(
            this IInterfaceFieldDescriptor descriptor,
            Type? type,
            PagingSettings settings = default)
        {
            if (descriptor is null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            if (type is null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            if (!typeof(IOutputType).IsAssignableFrom(type) || !type.IsClass)
            {
                throw new ArgumentException(
                    OffsetPagingObjectFieldDescriptorExtensions_SchemaTypeNotValid,
                    nameof(descriptor));
            }

            descriptor
                .AddOffsetPagingArguments()
                .Extend()
                .OnBeforeCreate((c, d) => d.Type = CreateTypeRef(c, d.Member, type, settings));

            return descriptor;
        }

        /// <summary>
        /// Adds the offset paging arguments to an object field.
        /// </summary>
        public static IObjectFieldDescriptor AddOffsetPagingArguments(
            this IObjectFieldDescriptor descriptor)
        {
            return descriptor
                .Argument(OffsetPagingArgumentNames.Skip, a => a.Type<IntType>())
                .Argument(OffsetPagingArgumentNames.Take, a => a.Type<IntType>());
        }

        /// <summary>
        /// Adds the offset paging arguments to an interface field.
        /// </summary>
        public static IInterfaceFieldDescriptor AddOffsetPagingArguments(
            this IInterfaceFieldDescriptor descriptor)
        {
            return descriptor
                .Argument(OffsetPagingArgumentNames.Skip, a => a.Type<IntType>())
                .Argument(OffsetPagingArgumentNames.Take, a => a.Type<IntType>());
        }

        private static ITypeReference CreateTypeRef(
            IDescriptorContext context,
            MemberInfo? resolverMember,
            Type? type,
            PagingSettings settings)
        {
            // first we will try and infer the schema type of the collection.
            IExtendedType schemaType = PagingHelper.GetSchemaType(
                context.TypeInspector,
                resolverMember,
                type);

            // we need to ensure that the schema type is a valid output type. For this we create a
            // type info which decomposes the type into its logical type components and is able 
            // to check if the named type component is really an output type.
            if (!context.TypeInspector.TryCreateTypeInfo(schemaType, out ITypeInfo? typeInfo) ||
                !typeInfo.IsOutputType())
            {
                throw OffsetPagingObjectFieldDescriptorExtensions_InvalidType();
            }

            settings = context.GetSettings(settings);

            // once we have identified the correct type we will create the 
            // paging result type from it.
            IExtendedType connectionType = context.TypeInspector.GetType(
                settings.IncludeTotalCount ?? false
                    ? typeof(CollectionSegmentCountType<>).MakeGenericType(schemaType.Source)
                    : typeof(CollectionSegmentType<>).MakeGenericType(schemaType.Source));

            // last but not leas we create a type reference that can be put on the field definition
            // to tell the type discovery that this field needs this result type.
            return TypeReference.Create(connectionType, TypeContext.Output);
        }

        private static OffsetPagingProvider ResolvePagingProvider(
            IServiceProvider services,
            IExtendedType source) =>
            services.GetServices<OffsetPagingProvider>().FirstOrDefault(p => p.CanHandle(source)) ??
                new QueryableOffsetPagingProvider();
    }
}
