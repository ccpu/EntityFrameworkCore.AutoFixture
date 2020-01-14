using AutoFixture;
using AutoFixture.NUnit3;
using EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Customizations;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Attributes
{
    public class AutoDomainDataWithInMemoryContextAttribute : AutoDataAttribute
    {
        public AutoDomainDataWithInMemoryContextAttribute()
            : base(() => new Fixture()
                .Customize(new DomainDataWithInMemoryContextCustomization()))
        {
        }
    }
}
