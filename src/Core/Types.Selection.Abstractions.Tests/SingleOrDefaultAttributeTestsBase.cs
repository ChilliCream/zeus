using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HotChocolate.Execution;
using HotChocolate.Resolvers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HotChocolate.Types.Selections
{
    public abstract class SingleOrDefaultAttributeTestsBase
    {
        private readonly IResolverProvider _provider;
        private readonly bool _setId;

        protected SingleOrDefaultAttributeTestsBase(IResolverProvider provider, bool setId = false)
        {
            _provider = provider;
            _setId = setId;
        }

        [Fact]
        public virtual void Execute_Selection_MultipleScalarShouldReturnOne()
        {
            // arrange
            IServiceCollection services;
            Func<IResolverContext, IEnumerable<Foo>> resolver;
            (services, resolver) = _provider.CreateResolver(
                Foo.Create("aa", 1, _setId));

            Foo resultCtx = null;
            ISchema schema = SchemaBuilder.New()
                .AddServices(services.BuildServiceProvider())
                .AddQueryType<Query>(d =>
                    d.Field(t => t.Foos)
                        .Resolver(resolver)
                        .Use(next => async ctx =>
                        {
                            await next(ctx).ConfigureAwait(false);
                            resultCtx = ctx.Result as Foo;
                        }))
                .Create();
            IQueryExecutor executor = schema.MakeExecutable();

            // act
            executor.Execute(
                 "{ foos { bar baz } }");

            // assert
            Assert.NotNull(resultCtx);
            Assert.Equal("aa", resultCtx.Bar);
            Assert.Equal(1, resultCtx.Baz);
            Assert.Null(resultCtx.Nested);
            Assert.Null(resultCtx.NestedCollection);
        }

        public class Query
        {
            [UseSingleOrDefault]
            [UseSelection]
            public IQueryable<Foo> Foos { get; }
        }

        public class Foo
        {
            private static int idCounter = 1;

            [Key]
            public int Id { get; set; }

            public string Bar { get; set; }

            public int Baz { get; set; }

            public NestedFoo Nested { get; set; }

            public List<NestedFoo> NestedCollection { get; set; }

            public static Foo Create(string bar, int baz, bool setId)
            {
                var value = new Foo
                {
                    Bar = bar,
                    Baz = baz,
                    Nested = new NestedFoo()
                    {
                        Bar = "nested" + bar,
                        Baz = baz * 2
                    },
                    NestedCollection = new List<NestedFoo>()
                       {
                        new NestedFoo()
                        {
                            Bar = "nestedcollection" + bar,
                            Baz = baz * 3
                        },
                       }
                };
                if (setId)
                {
                    value.Id = ++idCounter;
                }
                return value;
            }
        }

        public class NestedFoo
        {
            [Key]
            public int Id { get; set; }

            public string Bar { get; set; }

            public int Baz { get; set; }
        }
    }
}
