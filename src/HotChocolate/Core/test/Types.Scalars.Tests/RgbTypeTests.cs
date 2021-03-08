using System;
using HotChocolate.Language;
using Snapshooter.Xunit;
using Xunit;

namespace HotChocolate.Types.Scalars
{
    public class RgbTypeTests : ScalarTypeTestBase
    {
        [Fact]
        public void Schema_WithScalar_IsMatch()
        {
            // arrange
            ISchema schema = BuildSchema<RgbType>();

            // act
            // assert
            schema.ToString().MatchSnapshot();
        }

        [Theory]
        [InlineData(typeof(EnumValueNode), TestEnum.Foo, false)]
        [InlineData(typeof(FloatValueNode), 1d, false)]
        [InlineData(typeof(IntValueNode), 1, false)]
        [InlineData(typeof(BooleanValueNode), true, false)]
        [InlineData(typeof(StringValueNode), "", false)]
        [InlineData(typeof(StringValueNode), "rgb(255,0,0)", true)]
        [InlineData(typeof(StringValueNode), "rgb(100%, 0%, 0%)", true)]
        [InlineData(typeof(StringValueNode), "rgb(300,0,0)", true)]
        [InlineData(typeof(StringValueNode), "rgb(110%, 0%, 0%)", true)]
        [InlineData(typeof(StringValueNode), "rgb(100%,0%,60%)", true)]
        [InlineData(typeof(StringValueNode), "rgb(100%, 0%, 60%)", true)]
        [InlineData(typeof(NullValueNode), null, true)]
        public void IsInstanceOfType_GivenValueNode_MatchExpected(
            Type type,
            object value,
            bool expected)
        {
            // arrange
            IValueNode valueNode = CreateValueNode(type, value);

            // act
            // assert
            ExpectIsInstanceOfTypeToMatch<RgbType>(valueNode, expected);
        }

        [Theory]
        [InlineData(TestEnum.Foo, false)]
        [InlineData(1d, false)]
        [InlineData(1, false)]
        [InlineData(true, false)]
        [InlineData("", false)]
        [InlineData("rgb(255,0,0)", true)]
        [InlineData("rgb(100%, 0%, 0%)", true)]
        [InlineData("rgb(300,0,0)", true)]
        [InlineData("rgb(110%, 0%, 0%)", true)]
        [InlineData("rgb(100%,0%,60%)", true)]
        [InlineData("rgb(100%, 0%, 60%)", true)]
        [InlineData(null, true)]
        public void IsInstanceOfType_GivenObject_MatchExpected(object value, bool expected)
        {
            // arrange
            // act
            // assert
            ExpectIsInstanceOfTypeToMatch<RgbType>(value, expected);
        }

        [Theory]
        [InlineData(typeof(StringValueNode), "rgb(255,0,0)", "rgb(255,0,0)")]
        [InlineData(typeof(StringValueNode), "rgb(100%, 0%, 0%)", "rgb(100%, 0%, 0%)")]
        [InlineData(typeof(StringValueNode), "rgb(300,0,0)", "rgb(300,0,0)")]
        [InlineData(typeof(StringValueNode), "rgb(110%, 0%, 0%)", "rgb(110%, 0%, 0%)")]
        [InlineData(typeof(StringValueNode), "rgb(100%,0%,60%)", "rgb(100%,0%,60%)")]
        [InlineData(typeof(StringValueNode), "rgb(100%, 0%, 60%)", "rgb(100%, 0%, 60%)")]
        [InlineData(typeof(NullValueNode), null, null)]
        public void ParseLiteral_GivenValueNode_MatchExpected(
            Type type,
            object value,
            object expected)
        {
            // arrange
            IValueNode valueNode = CreateValueNode(type, value);

            // act
            // assert
            ExpectParseLiteralToMatch<RgbType>(valueNode, expected);
        }

        [Theory]
        [InlineData(typeof(EnumValueNode), TestEnum.Foo)]
        [InlineData(typeof(FloatValueNode), 1d)]
        [InlineData(typeof(IntValueNode), 1)]
        [InlineData(typeof(IntValueNode), 12345)]
        [InlineData(typeof(StringValueNode), "")]
        [InlineData(typeof(StringValueNode), "1")]
        [InlineData(typeof(StringValueNode), "rgb(255 0 153)")]
        [InlineData(typeof(StringValueNode), "rgb(255, 0, 153, 1)")]
        [InlineData(typeof(StringValueNode), "rgb(255, 0, 153, 100%)")]
        [InlineData(typeof(StringValueNode), "rgb(255 0 153 / 1)")]
        [InlineData(typeof(StringValueNode), "rgb(255 0 153 / 100%)")]
        [InlineData(typeof(StringValueNode), "rgb(255, 0, 153.6, 1)")]
        [InlineData(typeof(StringValueNode), "rgb(1e2, .5e1, .5e0, +.25e2%)")]
        [InlineData(typeof(StringValueNode), "hsl(270,60%,70%)")]
        [InlineData(typeof(StringValueNode), "hsla(240 100% 50% / .05)")]
        public void ParseLiteral_GivenValueNode_ThrowSerializationException(Type type, object value)
        {
            // arrange
            IValueNode valueNode = CreateValueNode(type, value);

            // act
            // assert
            ExpectParseLiteralToThrowSerializationException<RgbType>(valueNode);
        }
    }
}
