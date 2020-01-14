﻿using EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Persistence.Configuration;
using EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.AutoFixture.NUnit.Tests.Common.Persistence
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
