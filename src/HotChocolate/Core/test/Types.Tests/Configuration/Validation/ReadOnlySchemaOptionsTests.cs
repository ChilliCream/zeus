using Xunit;

namespace HotChocolate.Configuration.Validation
{
    public class ObjectTypeValidation : TypeValidationTestBase
    {
        [Fact]
        public void Implemented_Field_Is_UnionType_Field_Is_ObjectType()
        {
            ExpectValid(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    barOrBaz: BarOrBaz
                }

                type Foo implements FooInterface {
                    barOrBaz: Bar
                }

                union BarOrBaz = Bar | Baz

                type Bar {
                    bar: String
                }

                type Baz {
                    baz: String
                }
            ");
        }

        [Fact]
        public void Implemented_Field_Is_Interface_Field_Is_ObjectType()
        {
            ExpectValid(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    bar: BarInterface
                }

                type Foo implements FooInterface {
                    bar: Bar
                }

                interface BarInterface {
                    bar: String
                }

                type Bar implements BarInterface {
                    bar: String
                }
            ");
        }

        [Fact]
        public void Implemented_Field_Is_Interface_List_Field_Is_ObjectType_List()
        {
            ExpectValid(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    bar: [BarInterface]
                }

                type Foo implements FooInterface {
                    bar: [Bar]
                }

                interface BarInterface {
                    bar: String
                }

                type Bar implements BarInterface {
                    bar: String
                }
            ");
        }

        [Fact]
        public void Implemented_Field_Is_Interface_Field_Is_NonNull_ObjectType()
        {
            ExpectValid(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    bar: BarInterface
                }

                type Foo implements FooInterface {
                    bar: Bar!
                }

                interface BarInterface {
                    bar: String
                }

                type Bar implements BarInterface {
                    bar: String
                }
            ");
        }

        [Fact]
        public void Implemented_Field_Is_Nullable_Field_Is_NonNull()
        {
            ExpectValid(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    bar: String
                }

                type Foo implements FooInterface {
                    bar: String!
                }
            ");
        }

        [Fact]
        public void Implemented_Field_Is_NonNull_Field_Is_Nullable()
        {
            ExpectError(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    bar: String!
                }

                type Foo implements FooInterface {
                    bar: String
                }
            ");
        }

        [Fact]
        public void All_Arguments_Are_Implemented()
        {
            ExpectValid(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    abc(a: String): String
                }

                type Foo implements FooInterface {
                    abc(a: String): String
                }
            ");
        }

        [Fact]
        public void Arguments_Are_Not_Implemented()
        {
            ExpectError(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    abc(a: String): String
                }

                type Foo implements FooInterface {
                    abc: String
                }
            ");
        }

        [Fact]
        public void Implemented_Argument_Types_Do_Not_Match()
        {
            ExpectError(@"
                type Query {
                    foo: Foo
                }

                interface FooInterface {
                    abc(a: String): String
                }

                type Foo implements FooInterface {
                    abc(a: String!): String
                }
            ");
        }
    }
}
