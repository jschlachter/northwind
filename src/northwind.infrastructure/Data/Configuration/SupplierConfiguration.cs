using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;

namespace Northwind.Infrastructure.Data.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            //
            // Primary Key
            builder.HasKey(t => t.Id);

            //
            // Properties
            builder.Property(t => t.CompanyName).HasMaxLength(40).IsRequired();
            builder.Property(t => t.ContactName).HasMaxLength(30);
            builder.Property(t => t.ContactTitle).HasMaxLength(30);

            builder.Property(t => t.Phone).HasMaxLength(24);
            builder.Property(t => t.Fax).HasMaxLength(24);

            //
            // Table & Column Mappings
            builder.ToTable("Suppliers");
            builder.Property(t => t.Id).HasColumnName("SupplierID");

            //
            // Relationships

            builder.OwnsOne(supplier => supplier.Address, sa => {
                //
                // Properties
                sa.Property(p => p.Street1).HasMaxLength(60);
                sa.Property(p => p.City).HasMaxLength(15);
                sa.Property(p => p.Region).HasMaxLength(15);
                sa.Property(p => p.PostalCode).HasMaxLength(10);
                sa.Property(p => p.Country).HasMaxLength(15);

                //
                // Table & Column Mappings
                sa.Property(p => p.Street1).HasColumnName("Address");
                sa.Property(p => p.City).HasColumnName("City");
                sa.Property(p => p.Region).HasColumnName("Region");
                sa.Property(p => p.PostalCode).HasColumnName("PostalCode");
                sa.Property(p => p.Country).HasColumnName("Country");
            });
        }
    }
}
