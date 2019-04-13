using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;

namespace Northwind.Infrastructure.Data.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            //
            // Primary Key
            builder.HasKey(t => t.Id);

            //
            // Properties
            builder.Property(t => t.Description).HasMaxLength(50).IsRequired();

            //
            // Table & Column Mappings
            builder.ToTable("Regions");

            builder.Property(t => t.Id).HasColumnName("RegionID");
            builder.Property(t => t.Description).HasColumnName("RegionDescription");

            //
            // Relationships
        }
    }
}
