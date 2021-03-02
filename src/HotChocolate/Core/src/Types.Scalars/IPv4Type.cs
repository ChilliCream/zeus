using System;
using System.Text.RegularExpressions;
using HotChocolate.Language;

namespace HotChocolate.Types.Scalars
{
    /// <summary>
    /// The `IPv4` scalar type represents a valid a IPv4 address as defined here
    /// https://en.wikipedia.org/wiki/IPv4.
    /// </summary>
    public class IPv4Type : RegularExpressionType
    {
        private const string _validationPattern =
            "(^(?:(?:(?:0?0?[0-9]|0?[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.){3}(?:0?0?" +
            "[0-9]|0?[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(?:\\/(?:[0-9]|[1-2][0-9]|3[0" +
            "-2]))?)$)";

        /// <summary>
        /// Initializes a new instance of the <see cref="IPv4Type"/> class.
        /// </summary>
        public IPv4Type()
            : base(
                WellKnownScalarTypes.IPv4,
                _validationPattern,
                ScalarResources.IPv4Type_Description,
                RegexOptions.Compiled | RegexOptions.IgnoreCase)
        {
        }

        protected override Exception CreateParseLiteralError(StringValueNode valueSyntax)
        {
            return ThrowHelper.IPv4Type_ParseLiteral_IsInvalid(this);
        }

        protected override Exception CreateParseValueError(string runtimeValue)
        {
            return ThrowHelper.IPv4Type_ParseValue_IsInvalid(this);
        }
    }
}
