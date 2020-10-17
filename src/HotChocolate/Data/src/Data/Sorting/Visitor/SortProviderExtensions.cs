using System;
using HotChocolate.Types.Descriptors;

namespace HotChocolate.Data.Sorting
{
    public abstract class SortProviderExtensions<TContext>
        : ConventionExtension<SortProviderDefinition>,
          ISortProviderExtension,
          ISortProviderConvention
        where TContext : ISortVisitorContext
    {
        private Action<ISortProviderDescriptor<TContext>>? _configure;

        protected SortProviderExtensions()
        {
            _configure = Configure;
        }

        public SortProviderExtensions(Action<ISortProviderDescriptor<TContext>> configure)
        {
            _configure = configure ??
                throw new ArgumentNullException(nameof(configure));
        }

        void ISortProviderConvention.Initialize(IConventionContext context)
        {
            base.Initialize(context);
        }

        void ISortProviderConvention.OnComplete(IConventionContext context)
        {
            OnComplete(context);
        }

        protected override SortProviderDefinition CreateDefinition(IConventionContext context)
        {
            if (_configure is null)
            {
                throw new InvalidOperationException(DataResources.SortProvider_NoConfigurationSpecified);
            }

            var descriptor = SortProviderDescriptor<TContext>.New();

            _configure(descriptor);
            _configure = null;

            return descriptor.CreateDefinition();
        }

        protected virtual void Configure(ISortProviderDescriptor<TContext> descriptor) { }

        public override void Merge(IConventionContext context, Convention convention)
        {
            if (Definition is {} &&
                convention is SortProvider<TContext> conv &&
                conv.Definition is {} target)
            {
                // Provider extensions should be applied by default before the default handlers, as
                // the interceptor picks up the first handler. A provider extension should adds more
                // specific handlers than the default providers
                target.Handlers.InsertRange(0, Definition.Handlers);
                target.OperationHandlers.InsertRange(0, Definition.OperationHandlers);
            }
        }
    }
}
