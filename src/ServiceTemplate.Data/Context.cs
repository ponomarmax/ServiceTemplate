using System;
using Microsoft.EntityFrameworkCore;
using ServiceTemplate.Common;
using ServiceTemplate.Data.Entities;

namespace ServiceTemplate.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbContant.Schema);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            TestSeeding(modelBuilder);
        }

        private void TestSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestEntity>().HasData(new TestEntity { Id = Guid.NewGuid(), TestProperty = "TestName" });
        }
    }
}
