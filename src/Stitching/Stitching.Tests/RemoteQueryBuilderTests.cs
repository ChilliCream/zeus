using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ChilliCream.Testing;
using HotChocolate.Language;
using Xunit;

namespace HotChocolate.Stitching
{
    public class RemoteQueryBuilderTests
    {
        [Fact]
        public void BuildRemoteQuery()
        {
            // arrange
            Stack<SelectionPathComponent> path =
                SelectionPathParser.Parse("a.b.c.d(a: $fields:bar)");

            DocumentNode initialQuery =
                Parser.Default.Parse(
                    @"{
                        foo {
                          bar {
                            baz {
                              ... on Baz {
                                qux
                              }
                            }
                          }
                        }
                      }
                    ");

            FieldNode field = initialQuery.Definitions
                .OfType<OperationDefinitionNode>().Single()
                .SelectionSet.Selections
                .OfType<FieldNode>().Single()
                .SelectionSet.Selections
                .OfType<FieldNode>().Single();


            // act
            DocumentNode newQuery = RemoteQueryBuilder.New()
                .SetOperation(OperationType.Query)
                .SetSelectionPath(path)
                .SetRequestField(field)
                .AddVariable("fields_bar",
                    new NamedTypeNode(null, new NameNode("String")))
                .Build();

            // assert
            QuerySyntaxSerializer.Serialize(newQuery).Snapshot();
        }
    }
}
