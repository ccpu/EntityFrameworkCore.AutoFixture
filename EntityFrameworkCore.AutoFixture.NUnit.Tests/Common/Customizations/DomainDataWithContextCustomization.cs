using AutoFixture;
using AutoFixture.AutoMoq;
using EntityFrameworkCore.AutoFixture.Core;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Customizations
{
    public class DomainDataWithContextCustomization : CompositeCustomization
    {
        public DomainDataWithContextCustomization()
            : base(
                new IgnoredVirtualMembersCustomization(),
                new DbContextCustomization(),
                new AutoMoqCustomization())
        {
        }
    }
}
