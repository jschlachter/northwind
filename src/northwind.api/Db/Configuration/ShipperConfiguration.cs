using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Api.Models;

namespace Northwind.Api.Db.Configuration
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            //
            // Primary Key
            builder.HasKey(t => t.Id);

            //
            // Properties
            builder.Property(t => t.CompanyName).HasMaxLength(40).IsRequired();
            builder.Property(t => t.Phone).HasMaxLength(24);

            //
            // Table & Column Mappings
            builder.ToTable("Shippers");
            builder.Property(t => t.Id).HasColumnName("ShipperID");
            builder.Property(t => t.CompanyName).HasColumnName("CompanyName");
            builder.Property(t => t.Phone).HasColumnName("Phone");

            //
            // Relationships
        }
    }
}
