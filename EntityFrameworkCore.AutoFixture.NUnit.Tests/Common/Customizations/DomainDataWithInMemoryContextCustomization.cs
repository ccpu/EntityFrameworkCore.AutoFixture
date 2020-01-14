﻿using AutoFixture;
using AutoFixture.AutoMoq;
using EntityFrameworkCore.AutoFixture.InMemory;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Customizations
{
    public class DomainDataWithInMemoryContextCustomization : CompositeCustomization
    {
        public DomainDataWithInMemoryContextCustomization()
            : base(
                new IgnoredVirtualMembersCustomization(),
                new InMemoryContextCustomization(),
                new AutoMoqCustomization())
        {
        }
    }
}
