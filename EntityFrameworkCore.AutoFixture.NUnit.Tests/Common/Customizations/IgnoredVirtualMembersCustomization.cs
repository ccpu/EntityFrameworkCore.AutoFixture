using AutoFixture;
using EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.SpecimenBuilders;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Customizations
{
    public class IgnoredVirtualMembersCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new IgnoredVirtualMembersSpecimenBuilder());
        }
    }
}
