﻿using System;
using System.Linq;
using System.Threading;
using Moq;
using Xunit;

namespace HotChocolate.Resolvers
{
    public class FieldResolverBuilderTests
    {
        [Fact]
        public void CreateSourceMethodResolver()
        {
            // arrange
            Mock<IResolverContext> context = new Mock<IResolverContext>(MockBehavior.Strict);
            context.Setup(t => t.Parent<FooResolver>()).Returns(new FooResolver());

            FieldReference fieldReference = new FieldReference("type", "field");
            FieldResolverDescriptor descriptor = FieldResolverDescriptor
                .CreateSourceMethod(fieldReference, typeof(FooResolver),
                    "Bar", false, Array.Empty<FieldResolverArgumentDescriptor>());

            // act
            FieldResolverBuilder fieldResolverBuilder = new FieldResolverBuilder();
            FieldResolver[] resolvers = fieldResolverBuilder.Build(
                new[] { descriptor }).ToArray();

            // assert
            Assert.Collection(resolvers,
                r =>
                {
                    Assert.Equal("type", r.TypeName);
                    Assert.Equal("field", r.FieldName);
                    Assert.NotNull(r.Resolver);

                    object result = r.Resolver(context.Object, CancellationToken.None).Result;
                    Assert.Equal("Hello World", result);
                });
        }
    }

    public class FooResolver
    {
        public string Bar()
        {
            return "Hello World";
        }
    }
}