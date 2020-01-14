using AutoFixture;
using AutoFixture.AutoMoq;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Customizations
{
    public class DomainDataCustomization : CompositeCustomization
    {
        public DomainDataCustomization()
            : base(new AutoMoqCustomization())
        {
        }
    }
}
