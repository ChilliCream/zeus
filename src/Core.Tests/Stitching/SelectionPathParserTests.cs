using HotChocolate.Language;
using Xunit;

namespace HotChocolate.Stitching
{
    public class SelectionPathParserTests
    {
        [Fact]
        public void Parse_PathWithoutArgs_ThreeComponentsFound()
        {
            // arrange
            var serializedPath = new Source("foo.bar.baz");

            // act
            SelectionPath path = SelectionPathParser.Parse(serializedPath);

            // assert
            Assert.Collection(path.Components,
                t =>
                {
                    Assert.Equal("foo", t.Name.Value);
                    Assert.Empty(t.Arguments);
                },
                t =>
                {
                    Assert.Equal("bar", t.Name.Value);
                    Assert.Empty(t.Arguments);
                },
                t =>
                {
                    Assert.Equal("baz", t.Name.Value);
                    Assert.Empty(t.Arguments);
                });
        }

        [Fact]
        public void Parse_PathWithArgs_ThreeComponentsTwoWithArgs()
        {
            // arrange
            var serializedPath = new Source("foo(a: 1).bar.baz(b: \"s\")");

            // act
            SelectionPath path = SelectionPathParser.Parse(serializedPath);

            // assert
            Assert.Collection(path.Components,
                c =>
                {
                    Assert.Equal("foo", c.Name.Value);
                    Assert.Collection(c.Arguments,
                        a =>
                        {
                            Assert.Equal("a", a.Name.Value);
                            Assert.IsType<IntValueNode>(a.Value);
                        });
                },
                c =>
                {
                    Assert.Equal("bar", c.Name.Value);
                    Assert.Empty(c.Arguments);
                },
                c =>
                {
                    Assert.Equal("baz", c.Name.Value);
                    Assert.Collection(c.Arguments,
                        a =>
                        {
                            Assert.Equal("b", a.Name.Value);
                            Assert.IsType<StringValueNode>(a.Value);
                        });
                });
        }

        [Fact]
        public void Parse_PathWithVarArgs_ThreeComponentsOneWithVarArgs()
        {
            // arrange
            var serializedPath = new Source("foo(a: $foo:bar).bar.baz");

            // act
            SelectionPath path = SelectionPathParser.Parse(serializedPath);

            // assert
            Assert.Collection(path.Components,
                c =>
                {
                    Assert.Equal("foo", c.Name.Value);
                    Assert.Collection(c.Arguments,
                        a =>
                        {
                            Assert.Equal("a", a.Name.Value);
                            Assert.IsType<VariableNode>(a.Value);

                            var v = (VariableNode)a.Value;
                            Assert.Equal("foo:bar", v.Name.Value);
                        });
                },
                c =>
                {
                    Assert.Equal("bar", c.Name.Value);
                    Assert.Empty(c.Arguments);
                },
                c =>
                {
                    Assert.Equal("baz", c.Name.Value);
                    Assert.Empty(c.Arguments);
                });
        }
    }
}
