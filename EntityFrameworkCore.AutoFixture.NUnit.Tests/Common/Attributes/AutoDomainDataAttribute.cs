using AutoFixture;
using AutoFixture.NUnit3;
using EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Customizations;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Attributes
{
    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        public AutoDomainDataAttribute()
            : base(() => new Fixture()
                .Customize(new DomainDataCustomization()))
        {
        }
    }
}
