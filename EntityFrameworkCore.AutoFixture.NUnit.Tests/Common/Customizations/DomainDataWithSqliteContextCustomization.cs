using AutoFixture;
using AutoFixture.AutoMoq;
using EntityFrameworkCore.AutoFixture.Sqlite;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Customizations
{
    public class DomainDataWithSqliteContextCustomization : CompositeCustomization
    {
        public DomainDataWithSqliteContextCustomization()
            : base(
                new IgnoredVirtualMembersCustomization(),
                new SqliteContextCustomization(),
                new AutoMoqCustomization())
        {
        }
    }
}
