using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;

namespace Northwind.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //
            // Primary Key
            builder.HasKey(t => t.Id);

            //
            // Properties
            builder.Property(t => t.Name).HasMaxLength(40).IsRequired();
            builder.Property(t => t.QuantityPerUnit).HasMaxLength(20);
            builder.Property(t => t.Discontinued).IsRequired();

            //
            // Table & Column Mappings
            builder.ToTable("Products");
            builder.Property(t => t.Id).HasColumnName("ProductID");
            builder.Property(t => t.Name).HasColumnName("ProductName");
            builder.Property(t => t.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            builder.Property(t => t.UnitPrice).HasColumnName("UnitPrice").HasColumnType("money");
            builder.Property(t => t.UnitsInStock).HasColumnName("UnitsInStock");
            builder.Property(t => t.UnitsOnOrder).HasColumnName("UnitsOnOrder");

            //
            // Relationships
            builder.HasOne(t => t.Category).WithMany().HasForeignKey("CategoryID");
            builder.HasOne(t => t.Supplier).WithMany().HasForeignKey("SupplierID");
        }
    }
}
