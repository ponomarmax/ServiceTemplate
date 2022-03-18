using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceTemplate.Data.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Oneview.Inpatient.GVDIntegration.Data.Configurations
{
    [ExcludeFromCodeCoverage]
    class TestEntityConfiguration : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.ToTable(nameof(TestEntity));
            builder.HasKey(p => p.Id);
        }
    }
}
