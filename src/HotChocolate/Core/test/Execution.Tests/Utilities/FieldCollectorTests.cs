using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate.Language;
using HotChocolate.StarWars;
using HotChocolate.Types;
using Moq;
using Snapshooter.Xunit;
using Xunit;

namespace HotChocolate.Execution.Utilities
{
    public class FieldCollectorTests
    {
        [Fact]
        public void Prepare_One_Field()
        {
            // arrange
            ISchema schema = SchemaBuilder.New()
                .AddQueryType(c => c
                    .Name("Query")
                    .Field("foo")
                    .Type<StringType>()
                    .Resolver("foo"))
                .Create();

            DocumentNode document = Utf8GraphQLParser.Parse("{ foo }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            Assert.Collection(
                selectionSets.Values,
                selectionSet =>
                {
                    Assert.Equal(operation.SelectionSet, selectionSet.SelectionSet);
                    Assert.Collection(
                        selectionSet.GetSelections(schema.QueryType),
                        selection => Assert.Equal("foo", selection.ResponseName));
                });
        }

        [Fact]
        public void Prepare_Duplicate_Field()
        {
            // arrange
            ISchema schema = SchemaBuilder.New()
                .AddQueryType(c => c
                    .Name("Query")
                    .Field("foo")
                    .Type<StringType>()
                    .Resolver("foo"))
                .Create();

            DocumentNode document = Utf8GraphQLParser.Parse("{ foo foo }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            Assert.Collection(
                selectionSets.Values,
                selectionSet =>
                {
                    Assert.Equal(operation.SelectionSet, selectionSet.SelectionSet);
                    Assert.Collection(
                        selectionSet.GetSelections(schema.QueryType),
                        selection => Assert.Equal("foo", selection.ResponseName));
                });
        }

        [Fact]
        public void Prepare_Inline_Fragment()
        {
            // arrange
            ISchema schema = SchemaBuilder.New()
                .AddStarWarsTypes()
                .Create();

            DocumentNode document = Utf8GraphQLParser.Parse(
            @"{
                hero(episode: EMPIRE) {
                    name
                    ... on Droid {
                        primaryFunction
                    }
                    ... on Human {
                        homePlanet
                    }
                }
             }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            IPreparedSelection hero = selectionSets[operation.SelectionSet].GetSelections(schema.QueryType).Single();
            Assert.Equal("hero", hero.ResponseName);

            Assert.Collection(
                selectionSets[hero.SelectionSet].GetSelections(schema.GetType<ObjectType>("Droid")),
                selection => Assert.Equal("name", selection.ResponseName),
                selection => Assert.Equal("primaryFunction", selection.ResponseName));

            Assert.Collection(
                selectionSets[hero.SelectionSet].GetSelections(schema.GetType<ObjectType>("Human")),
                selection => Assert.Equal("name", selection.ResponseName),
                selection => Assert.Equal("homePlanet", selection.ResponseName));

            var op = new PreparedOperation(
                "abc",
                document,
                operation,
                schema.QueryType,
                selectionSets);
            op.Print().MatchSnapshot();
        }

        [Fact]
        public void Prepare_Fragment_Definition()
        {
            // arrange
            ISchema schema = SchemaBuilder.New()
                .AddStarWarsTypes()
                .Create();

            DocumentNode document = Utf8GraphQLParser.Parse(
            @"{
                hero(episode: EMPIRE) {
                    name
                    ... abc
                    ... def
                }
              }

              fragment abc on Droid {
                  primaryFunction
              }

              fragment def on Human {
                  homePlanet
              }
             ");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            var op = new PreparedOperation(
                "abc",
                document,
                operation,
                schema.QueryType,
                selectionSets);
            op.Print().MatchSnapshot();
        }

        [Fact]
        public void Prepare_Duplicate_Field_With_Skip()
        {
            // arrange
            ISchema schema = SchemaBuilder.New()
                .AddQueryType(c => c
                    .Name("Query")
                    .Field("foo")
                    .Type<StringType>()
                    .Resolver("foo"))
                .Create();

            DocumentNode document = Utf8GraphQLParser.Parse("{ foo @skip(if: true) foo @skip(if: false) }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            Assert.Collection(
                selectionSets.Values,
                selectionSet =>
                {
                    Assert.Equal(operation.SelectionSet, selectionSet.SelectionSet);
                    Assert.Collection(
                        selectionSet.GetSelections(schema.QueryType),
                        selection => Assert.Equal("foo", selection.ResponseName));
                });
        }

        [Fact]
        public void Field_Does_Not_Exist()
        {
            // arrange
            ISchema schema = SchemaBuilder.New()
                .AddQueryType(c => c
                    .Name("Query")
                    .Field("foo")
                    .Type<StringType>()
                    .Resolver("foo"))
                .Create();

            DocumentNode document = Utf8GraphQLParser.Parse("{ foo bar }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            Action action = () =>
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            Assert.Equal(
                "Field `bar` does not exist on type `Query`.",
                Assert.Throws<GraphQLException>(action).Message);
        }

        [Fact]
        public void Field_Is_Visible_When_One_Selection_Is_Visible_1()
        {
            // arrange
            var variables = new Mock<IVariableValueCollection>();
            variables.Setup(t => t.GetVariable<bool>(It.IsAny<NameString>())).Returns(false);

            ISchema schema = SchemaBuilder.New()
                .AddStarWarsTypes()
                .Create();

            ObjectType droid = schema.GetType<ObjectType>("Droid");

            DocumentNode document = Utf8GraphQLParser.Parse(
                @"query foo($v: Boolean){
                    hero(episode: EMPIRE) {
                        name
                        ... abc @include(if: $v)
                    }
                }

                fragment abc on Droid {
                    name
                }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            var op = new PreparedOperation(
                "abc",
                document,
                operation,
                schema.QueryType,
                selectionSets);
            IPreparedSelectionList rootSelections =
                op.RootSelectionSet.GetSelections(op.RootSelectionSet.GetPossibleTypes().First());
            IPreparedSelectionList droidSelections =
                op.GetSelections(rootSelections[0].SelectionSet, droid);

            Assert.Equal("name", droidSelections[0].ResponseName);
            Assert.Equal(true, droidSelections[0].IsFinal);
            Assert.Equal(true, droidSelections[0].IsVisible(variables.Object));
            Assert.Equal(true, droidSelections.IsFinal);
        }

        [Fact]
        public void Field_Is_Visible_When_One_Selection_Is_Visible_2()
        {
            // arrange
            var variables = new Mock<IVariableValueCollection>();
            variables.Setup(t => t.GetVariable<bool>(It.IsAny<NameString>())).Returns(false);

            ISchema schema = SchemaBuilder.New()
                .AddStarWarsTypes()
                .Create();

            ObjectType droid = schema.GetType<ObjectType>("Droid");

            DocumentNode document = Utf8GraphQLParser.Parse(
                @"query foo($v: Boolean){
                    hero(episode: EMPIRE) {
                        name @include(if: $v)
                        ... abc
                    }
                }

                fragment abc on Droid {
                    name
                }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            var op = new PreparedOperation(
                "abc",
                document,
                operation,
                schema.QueryType,
                selectionSets);
            IPreparedSelectionList rootSelections =
                op.RootSelectionSet.GetSelections(op.RootSelectionSet.GetPossibleTypes().First());
            IPreparedSelectionList droidSelections =
                op.GetSelections(rootSelections[0].SelectionSet, droid);

            Assert.Equal("name", droidSelections[0].ResponseName);
            Assert.Equal(true, droidSelections[0].IsFinal);
            Assert.Equal(true, droidSelections[0].IsVisible(variables.Object));
            Assert.Equal(true, droidSelections.IsFinal);
        }

        [Fact]
        public void Field_Is_Visible_When_One_Selection_Is_Visible_3()
        {
            // arrange
            var variables = new Mock<IVariableValueCollection>();
            variables.Setup(t => t.GetVariable<bool>(It.IsAny<NameString>()))
                .Returns((NameString name) => 
                {
                    return name.Equals("q");
                });

            ISchema schema = SchemaBuilder.New()
                .AddStarWarsTypes()
                .Create();

            ObjectType droid = schema.GetType<ObjectType>("Droid");

            DocumentNode document = Utf8GraphQLParser.Parse(
                @"query foo($v: Boolean, $q: Boolean){
                    hero(episode: EMPIRE) {
                        name @include(if: $v)
                        ... abc @include(if: $q)
                    }
                }

                fragment abc on Droid {
                    name
                }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            var op = new PreparedOperation(
                "abc",
                document,
                operation,
                schema.QueryType,
                selectionSets);
            IPreparedSelectionList rootSelections =
                op.RootSelectionSet.GetSelections(op.RootSelectionSet.GetPossibleTypes().First());
            IPreparedSelectionList droidSelections =
                op.GetSelections(rootSelections[0].SelectionSet, droid);

            Assert.Equal("name", droidSelections[0].ResponseName);
            Assert.Equal(false, droidSelections[0].IsFinal);
            Assert.Equal(true, droidSelections[0].IsVisible(variables.Object));
            Assert.Equal(false, droidSelections.IsFinal);
        }

        [Fact]
        public void Field_Is_Visible_When_One_Selection_Is_Visible_4()
        {
            // arrange
            var variables = new Mock<IVariableValueCollection>();
            variables.Setup(t => t.GetVariable<bool>(It.IsAny<NameString>())).Returns(false);

            ISchema schema = SchemaBuilder.New()
                .AddStarWarsTypes()
                .Create();

            ObjectType droid = schema.GetType<ObjectType>("Droid");

            DocumentNode document = Utf8GraphQLParser.Parse(
                @"query foo($v: Boolean){
                    hero(episode: EMPIRE) {
                        name @include(if: $v)
                        ... abc
                    }
                }

                fragment abc on Droid {
                    name
                    ... {
                        name
                    }
                }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            var op = new PreparedOperation(
                "abc",
                document,
                operation,
                schema.QueryType,
                selectionSets);
            IPreparedSelectionList rootSelections =
                op.RootSelectionSet.GetSelections(op.RootSelectionSet.GetPossibleTypes().First());
            IPreparedSelectionList droidSelections =
                op.GetSelections(rootSelections[0].SelectionSet, droid);

            Assert.Equal("name", droidSelections[0].ResponseName);
            Assert.Equal(true, droidSelections[0].IsFinal);
            Assert.Equal(true, droidSelections[0].IsVisible(variables.Object));
            Assert.Equal(true, droidSelections.IsFinal);
        }

        [Fact]
        public void Field_Object_Visibility_1()
        {
            // arrange
            var variables = new Mock<IVariableValueCollection>();
            variables.Setup(t => t.GetVariable<bool>(It.IsAny<NameString>())).Returns(false);

            ISchema schema = SchemaBuilder.New()
                .AddStarWarsTypes()
                .Create();

            ObjectType droid = schema.GetType<ObjectType>("Droid");

            DocumentNode document = Utf8GraphQLParser.Parse(
                @"query foo($v: Boolean){
                    hero(episode: EMPIRE) @include(if: $v) {
                        name
                    }
                    ... on Query {
                        hero(episode: EMPIRE) {
                            id
                        }
                    }
                    ... @include(if: $v) {
                        hero(episode: EMPIRE) {
                            height
                        }
                    }
                }");

            OperationDefinitionNode operation =
                document.Definitions.OfType<OperationDefinitionNode>().Single();

            var fragments = new FragmentCollection(schema, document);

            // act
            IReadOnlyDictionary<SelectionSetNode, PreparedSelectionSet> selectionSets =
                FieldCollector.PrepareSelectionSets(schema, fragments, operation);

            // assert
            var op = new PreparedOperation(
                "abc",
                document,
                operation,
                schema.QueryType,
                selectionSets);
            IPreparedSelectionList rootSelections =
                op.RootSelectionSet.GetSelections(op.RootSelectionSet.GetPossibleTypes().First());
            IPreparedSelectionList droidSelections =
                op.GetSelections(rootSelections[0].SelectionSet, droid);

            
        }
    }
}
