using System;
using AutoFixture;
using AutoFixture.Idioms;
using AutoFixture.Kernel;
using AutoFixture.NUnit3;
using EntityFrameworkCore.AutoFixture.Core;
using EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Attributes;
using EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Core
{
    public class DbContextSpecimenBuilderTests
    {
        [Test]
        [AutoDomainData]
        public void Create_ShouldThrowArgumentException_WhenSpecimenContextNull(
            DbContextSpecimenBuilder builder)
        {
            Action act = () => builder.Create(typeof(TestDbContext), null);

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        [AutoDomainData]
        public void Create_ShouldReturnNoSpecimen_WhenRequestTypeNotDbContext(
            DbContextSpecimenBuilder builder,
            Mock<ISpecimenContext> contextMock)
        {
            var actual = builder.Create(typeof(string), contextMock.Object);

            actual.Should().BeOfType<NoSpecimen>();
        }

        [Test]
        [AutoDomainData]
        public void Create_ShouldReturnNoSpecimen_WhenRequestIsPropertyInfo(
            DbContextSpecimenBuilder builder,
            Mock<ISpecimenContext> contextMock)
        {
            var property = typeof(string).GetProperty(nameof(string.Length));
            var actual = builder.Create(property, contextMock.Object);

            actual.Should().BeOfType<NoSpecimen>();
        }

        [Test]
        [AutoDomainData]
        public void Create_ShouldReturnNoSpecimen_WhenRequestNotType(
            [Frozen] Mock<IRequestSpecification> requestSpecificationMock,
            Mock<ISpecimenContext> contextMock,
            [Greedy] DbContextSpecimenBuilder builder)
        {
            requestSpecificationMock
                .Setup(x => x.IsSatisfiedBy(It.IsAny<object>()))
                .Returns(true);

            var property = typeof(string).GetProperty(nameof(string.Length));
            var actual = builder.Create(property, contextMock.Object);

            actual.Should().BeOfType<NoSpecimen>();
        }

        [Test]
        [AutoDomainData]
        public void Create_ShouldReturnNoSpecimen_WhenContextCanNotResolveOptions(
            DbContextSpecimenBuilder builder,
            Mock<ISpecimenContext> contextMock)
        {
            contextMock.Setup(x => x.Resolve(typeof(DbContextOptions<TestDbContext>)))
                       .Returns(new NoSpecimen());

            var actual = builder.Create(typeof(TestDbContext), contextMock.Object);

            actual.Should().BeOfType<NoSpecimen>();
        }

        [Test]
        [AutoDomainData]
        public void Create_ShouldReturnOmitSpecimen_WhenContextSkipsOptionsResolution(
            DbContextSpecimenBuilder builder,
            Mock<ISpecimenContext> contextMock)
        {
            contextMock.Setup(x => x.Resolve(typeof(DbContextOptions<TestDbContext>)))
                       .Returns(new OmitSpecimen());

            var actual = builder.Create(typeof(TestDbContext), contextMock.Object);

            actual.Should().BeOfType<OmitSpecimen>();
        }

        [Test]
        [AutoDomainData]
        public void Create_ShouldReturnNull_WhenContextResolvesOptionsAsNull(
            DbContextSpecimenBuilder builder,
            Mock<ISpecimenContext> contextMock)
        {
            contextMock.Setup(x => x.Resolve(typeof(DbContextOptions<TestDbContext>)))
                       .Returns(null);

            var actual = builder.Create(typeof(TestDbContext), contextMock.Object);

            actual.Should().BeNull();
        }

        [Test]
        [AutoDomainData]
        public void Create_ShouldBeOfRequestedType_WhenContextResolvesOptions(
            DbContextSpecimenBuilder builder,
            Mock<ISpecimenContext> contextMock)
        {
            contextMock.Setup(x => x.Resolve(typeof(DbContextOptions<TestDbContext>)))
                       .Returns(new DbContextOptionsBuilder<TestDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .Options);

            var actual = builder.Create(typeof(TestDbContext), contextMock.Object);

            actual.Should().BeOfType<TestDbContext>();
        }

        [Test]
        [AutoDomainData]
        public void Ctors_ShouldReceiveInitializedParameters(Fixture fixture)
        {
            var assertion = new GuardClauseAssertion(fixture);
            var members = typeof(DbContextSpecimenBuilder).GetConstructors();

            assertion.Verify(members);
        }
    }
}
