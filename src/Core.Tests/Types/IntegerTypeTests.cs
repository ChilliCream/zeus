using HotChocolate.Language;
using Xunit;

namespace HotChocolate.Types
{
    public class IntTypeTests
    {
        [Fact]
        public void Serialize_Int()
        {
            // arrange
            IntType type = new IntType();
            int input = 1;

            // act
            object serializedValue = type.Serialize(input);

            // assert
            Assert.IsType<int>(serializedValue);
            Assert.Equal(1, serializedValue);
        }

        [Fact]
        public void Serialize_Null()
        {
            // arrange
            IntType type = new IntType();

            // act
            object serializedValue = type.Serialize(null);

            // assert
            Assert.Null(serializedValue);
        }

        [Fact]
        public void ParseLiteral_IntValueNode()
        {
            // arrange
            IntType type = new IntType();
            IntValueNode input = new IntValueNode("1");

            // act
            object output = type.ParseLiteral(input);

            // assert
            Assert.IsType<int>(output);
            Assert.Equal(1, output);
        }

        [Fact]
        public void ParseLiteral_NullValueNode()
        {
            // arrange
            IntType type = new IntType();
            NullValueNode input = new NullValueNode();

            // act
            object output = type.ParseLiteral(input);

            // assert
            Assert.Null(output);
        }

        [Fact]
        public void ParseValue_Int_Max()
        {
            // arrange
            IntType type = new IntType();
            int input = int.MaxValue;
            string expectedLiteralValue = "2147483647";

            // act
            IntValueNode literal =
                (IntValueNode)type.ParseValue(input);

            // assert
            Assert.Equal(expectedLiteralValue, literal.Value);
        }

        [Fact]
        public void ParseValue_Int_Min()
        {
            // arrange
            IntType type = new IntType();
            int input = int.MinValue;
            string expectedLiteralValue = "-2147483648";

            // act
            IntValueNode literal =
                (IntValueNode)type.ParseValue(input);

            // assert
            Assert.Equal(expectedLiteralValue, literal.Value);
        }

        [Fact]
        public void ParseValue_Null()
        {
            // arrange
            IntType type = new IntType();
            object input = null;

            // act
            object output = type.ParseValue(input);

            // assert
            Assert.IsType<NullValueNode>(output);
        }


        [Fact]
        public void EnsureFloatTypeKindIsCorret()
        {
            // arrange
            IntType type = new IntType();

            // act
            TypeKind kind = type.Kind;

            // assert
            Assert.Equal(TypeKind.Scalar, kind);
        }
    }
}
