using System;
using HotChocolate.Types.Descriptors;

namespace HotChocolate.Data.Filters
{
    public abstract class FilterProviderExtensions<TContext>
        : ConventionExtension<FilterProviderDefinition>,
          IFilterProviderExtension,
          IFilterProviderConvention
        where TContext : IFilterVisitorContext
    {
        private Action<IFilterProviderDescriptor<TContext>>? _configure;

        protected FilterProviderExtensions()
        {
            _configure = Configure;
        }

        public FilterProviderExtensions(Action<IFilterProviderDescriptor<TContext>> configure)
        {
            _configure = configure ??
                throw new ArgumentNullException(nameof(configure));
        }

        void IFilterProviderConvention.Initialize(IConventionContext context)
        {
            base.Initialize(context);
        }

        void IFilterProviderConvention.OnComplete(IConventionContext context)
        {
            OnComplete(context);
        }

        protected override FilterProviderDefinition CreateDefinition(IConventionContext context)
        {
            if (_configure is null)
            {
                throw new InvalidOperationException(DataResources.FilterProvider_NoConfigurationSpecified);
            }

            var descriptor = FilterProviderDescriptor<TContext>.New();

            _configure(descriptor);
            _configure = null;

            return descriptor.CreateDefinition();
        }

        protected virtual void Configure(IFilterProviderDescriptor<TContext> descriptor) { }

        public override void Merge(IConventionContext context, Convention convention)
        {
            if (Definition is {} &&
                convention is FilterProvider<TContext> conv &&
                conv.Definition is {} target)
            {
                // Provider extensions should be applied by default before the default handlers, as
                // the interceptor picks up the first handler. A provider extension should adds more
                // specific handlers than the default providers
                target.Handlers.InsertRange(0, Definition.Handlers);
            }
        }
    }
}
