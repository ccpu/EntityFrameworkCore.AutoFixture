using System;
using AutoFixture;
using AutoFixture.NUnit3;
using EntityFrameworkCore.AutoFixture.Core;
using FluentAssertions;
using NUnit.Framework;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Core
{
    public class DbContextCustomizationTests
    {
        [Test]
        [AutoData]
        public void Customize_ShouldAddContextBuilderToFixture(
            Fixture fixture,
            DbContextCustomization customization)
        {
            fixture.Customize(customization);

            fixture.Customizations.Should()
                .ContainSingle(x => x.GetType() == typeof(DbContextSpecimenBuilder));
        }

        [Test]
        [AutoData]
        public void Customize_ShouldAddOptionsBuilderToFixture(
            Fixture fixture,
            DbContextCustomization customization)
        {
            fixture.Customize(customization);

            fixture.Customizations.Should()
                .ContainSingle(x => x.GetType() == typeof(DbContextOptionsSpecimenBuilder));
        }

        [Test]
        [AutoData]
        public void Customize_ForNullFixture_ShouldThrow(
            DbContextCustomization customization)
        {
            Action act = () => customization.Customize(default);

            act.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
