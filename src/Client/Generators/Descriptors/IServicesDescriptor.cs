using System.Collections.Generic;

namespace StrawberryShake.Generators.Descriptors
{
    public interface IServicesDescriptor
        : ICodeDescriptor
    {
        IClientDescriptor Client { get; }

        IReadOnlyCollection<IEnumDescriptor> EnumTypes { get; }

        IReadOnlyCollection<IResultParserDescriptor> ResultParsers { get; }
    }
}
