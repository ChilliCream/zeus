using System;

namespace HotChocolate.Resolvers
{
    internal sealed class DirectiveResolverMiddleware
        : IDirectiveMiddleware
    {
        public DirectiveResolverMiddleware(
            string directiveName,
            OnInvokeResolver resolver)
        {
            if (string.IsNullOrEmpty(directiveName))
            {
                throw new ArgumentNullException(nameof(directiveName));
            }

            DirectiveName = directiveName;
            Resolver = resolver
                ?? throw new ArgumentNullException(nameof(resolver));
        }

        public string DirectiveName { get; }
        public MiddlewareKind Kind => MiddlewareKind.OnInvoke;
        public OnInvokeResolver Resolver { get; }
    }
}
