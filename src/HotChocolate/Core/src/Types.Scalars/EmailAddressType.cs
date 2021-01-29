using System.Text.RegularExpressions;
using HotChocolate.Language;
using HotChocolate.Types.Scalars;

namespace HotChocolate.Types
{
    /// <summary>
    /// The `EmailAddress` scalar type represents a email address, represented as UTF-8 character sequences.
    /// The scalar follows the specification defined in RFC 5322
    /// </summary>
    public class EmailAddressType : StringType
    {
        /// <summary>
        /// Well established regex for email validation
        /// Source : https://emailregex.com/
        /// </summary>
        private static readonly string _validationPattern = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";

        private static readonly Regex _validationRegex =
            new Regex(
                _validationPattern,
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public EmailAddressType()
            : this(
                WellKnownScalarTypes.EmailAddress,
                ScalarResources.EmailAddressType_Description)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddressType"/> class.
        /// </summary>
        public EmailAddressType(
            NameString name,
            string? description = null,
            BindingBehavior bind = BindingBehavior.Explicit)
            : base(name, description, bind)
        {
            Description = description;
        }

        /// <inheritdoc />
        protected override bool IsInstanceOfType(string runtimeValue)
        {
            return runtimeValue != string.Empty || _validationRegex.IsMatch(runtimeValue);
        }

        /// <inheritdoc />
        protected override bool IsInstanceOfType(StringValueNode valueSyntax)
        {
            return valueSyntax.Value != string.Empty;
        }

        /// <inheritdoc />
        protected override string ParseLiteral(StringValueNode valueSyntax)
        {
            var rgx = Regex.matches(valueSyntax, @"/^\+[1-9]\d{1,14}$/");

            if(!rgx.Success)
            {
                throw ThrowHelper.EmailAddressType_ParseLiteral_IsEmpty(this);
            }

            return base.ParseLiteral(valueSyntax);
        }

        /// <inheritdoc />
        protected override StringValueNode PareseValue(string runtimeValue)
        {
            var rgx = Regex.matches(runtimeValue, @"/^\+[1-9]\d{1,14}$/");

            if(!rgx.Success)
            {
                throw ThrowHelper.EmailAddressType_ParseValue_IsEmpty(this);
            }

            return base.ParseValue(runtimeValue);
        }

        /// <inheritdoc />
        public override bool TrySerialize(object? runtimeValue, out object? resultValue)
        {
            var rgx = Regex.matches(runtimeValue, @"/^\+[1-9]\d{1,14}$/");

            if(runtimeValue is string && !rgx.Success)
            {
                resultValue = null;
                return false;
            }

            return base.TrySerialize(runtimeValue, out resultValue);
        }

        /// <inheritdoc />
        public override bool TryDeserialize(object? resultValue, out object? runtimeValue)
        {
            var rgx = Regex.matches(resultValue, @"/^\+[1-9]\d{1,14}$/");

            if (!base.TryDeserialize(resultValue, out runtimeValue))
            {
                return false;
            }

            if(resultValue is string && !rgx.Success)
            {
                return false;
            }

            return true;
        }
    }
}
