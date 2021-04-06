using System;
using System.Collections.Generic;

#nullable enable

namespace HotChocolate.Types.Relay
{
    internal class PolymorphicGlobalIdInputValueFormatter : IInputValueFormatter
    {
        private readonly NameString _schemaName;
        private readonly NameString _nodeTypeName;
        private readonly Type _idRuntimeType;
        private readonly IIdSerializer _idSerializer;

        public PolymorphicGlobalIdInputValueFormatter(
            NameString nodeTypeName,
            Type idRuntimeType,
            IIdSerializer idSerializer)
        {
            _schemaName = null; // not needed during deserialization
            _nodeTypeName = nodeTypeName;
            _idRuntimeType = idRuntimeType;
            _idSerializer = idSerializer;
        }

        public object? OnAfterDeserialize(object? runtimeValue)
        {
            if (runtimeValue is null)
            {
                return null;
            }

            if (runtimeValue is string s)
            {
                return DeserializeId(s);
            }

            if (runtimeValue is IEnumerable<string?> stringEnumerable)
            {
                try
                {
                    var list = new List<IdValue?>();
                    foreach (var sv in stringEnumerable)
                    {
                        if (sv is null)
                        {
                            list.Add(null);
                        }
                        else
                        {
                            list.Add(DeserializeId(sv));
                        }
                    }
                    return list;
                }
                catch
                {
                    throw new GraphQLException(
                        ErrorBuilder.New()
                            .SetMessage(
                                "The IDs `{0}` have an invalid format.",
                                string.Join(", ", stringEnumerable))
                            .Build());
                }
            }

            // Let fall through to default formatter
            return runtimeValue;
        }

        private IdValue DeserializeId(string value)
        {
            if (_idRuntimeType == typeof(int) && value is string rawIntString &&
                int.TryParse(rawIntString, out var intValue))
            {
                return new IdValue(_schemaName, _nodeTypeName, intValue);
            }

            if (_idRuntimeType == typeof(int?))
            {
                if (value is null)
                {
                    return new IdValue(_schemaName, _nodeTypeName, null);
                }
                else if (value is string rawIntString2 &&
                    int.TryParse(rawIntString2, out var intValue2))
                {
                    return new IdValue(_schemaName, _nodeTypeName, intValue2);
                }
            }

            if (_idRuntimeType == typeof(long) && value is string rawLongString &&
                long.TryParse(rawLongString, out var longValue))
            {
                return new IdValue(_schemaName, _nodeTypeName, longValue);
            }

            if (_idRuntimeType == typeof(long?))
            {
                if (value is null)
                {
                    return new IdValue(_schemaName, _nodeTypeName, null);
                }
                else if (value is string rawLongString2 &&
                    long.TryParse(rawLongString2, out var longValue2))
                {
                    return new IdValue(_schemaName, _nodeTypeName, longValue2);
                }
            }

            if (_idRuntimeType == typeof(Guid) && value is string rawGuidString &&
                Guid.TryParse(rawGuidString, out Guid guidValue))
            {
                return new IdValue(_schemaName, _nodeTypeName, guidValue);
            }

            if (_idRuntimeType == typeof(Guid?))
            {
                if (value is null)
                {
                    return new IdValue(_schemaName, _nodeTypeName, null);
                }
                else if (value is string rawGuidString2 &&
                    Guid.TryParse(rawGuidString2, out Guid guidValue2))
                {
                    return new IdValue(_schemaName, _nodeTypeName, guidValue2);
                }
            }

            try
            {
                return _idSerializer.Deserialize(value);
            }
            catch
            {
                // Allow to fall through as this is likely a non-serialized id
                // There is a slight chance it's not, but we let it slide
                return new IdValue(_schemaName, _nodeTypeName, value);
            }
        }
    }
}
