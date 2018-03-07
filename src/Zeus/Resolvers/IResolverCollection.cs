using System;

namespace Zeus.Resolvers
{
    public interface IResolverCollection
    {
        bool TryGetResolver(string typeName, string fieldName, out ResolverDelegate resolver);
    }

    public interface IResolverCollection2
    {
        ResolverDelegate TryGetResolver(string typeName, string fieldName, out ResolverDelegate resolver);
    }
}
