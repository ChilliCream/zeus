using System.Threading.Tasks;
using HotChocolate.Execution;
using HotChocolate.Types;
using Xunit;

namespace HotChocolate.Resolvers
{
    public class ParentAttributeTests
    {
        [Fact]
        public async Task GenericObjectType_ParentResolver_BindsParentCorrectly()
        {
            // arrange
            var objectType = new ObjectType<Foo>(
                t => t.Field<FooResolver>(f => f.GetParent(default)).Name("desc"));
            var schema = Schema.Create(t => t.RegisterQueryType(objectType));
            IRequestExecutor executor = schema.MakeExecutable();

            // act
            IExecutionResult result = await executor.ExecuteAsync(
                QueryRequestBuilder.New()
                    .SetQuery("{ desc }")
                    .SetInitialValue(new Foo())
                    .Create());

            // assert
            var queryResult = result as QueryResult;
            Assert.NotNull(queryResult);
            Assert.Null(queryResult.Errors);
            Assert.Equal("hello", queryResult.Data?["desc"]);
        }

        [Fact]
        public async Task ObjectType_ParentResolver_BindsParentCorrectly()
        {
            // arrange
            var objectType = new ObjectType(t => t.Name("Bar")
                .Field<FooResolver>(f => f.GetParent(default))
                .Name("desc")
                .Type<StringType>());
            var schema = Schema.Create(t => t.RegisterQueryType(objectType));
            IRequestExecutor executor = schema.MakeExecutable();

            // act
            IExecutionResult result = await executor.ExecuteAsync(
                QueryRequestBuilder.New()
                    .SetQuery("{ desc }")
                    .SetInitialValue(new Foo())
                    .Create());

            // assert
            var queryResult = result as QueryResult;
            Assert.NotNull(queryResult);
            Assert.Null(queryResult.Errors);
            Assert.Equal("hello", queryResult.Data?["desc"]);
        }

        public class Foo
        {
            public Bar Bar { get; } = new();
            public string Description => "hello";
        }

        public class Bar : IBar
        {
            public string Description => "nested";
        }

        public interface IBar
        {
            string Description { get; }
        }

        public class FooResolver
        {
            public string GetParent([Parent]Foo foo) => foo.Description;
            public string GetPure() => "foo";
        }
    }
}
