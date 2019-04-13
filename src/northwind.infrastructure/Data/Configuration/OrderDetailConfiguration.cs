using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;

namespace Northwind.Infrastructure.Data.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {

            builder.Property<int>("OrderID");
            builder.Property<int>("ProductID");

            //
            // Primary Key
            builder.HasKey("OrderID", "ProductID");

            //
            // Properties
            builder.Property(t => t.UnitPrice).IsRequired();
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.Discount).IsRequired();


            //
            // Table & Column Mappings
            builder.ToTable("Order Details");

            builder.Property(t => t.UnitPrice).HasColumnName("money").HasColumnType("money");
            builder.Property(t => t.Quantity).HasColumnName("Quantity");
            builder.Property(t => t.Discount).HasColumnName("Discount").HasColumnType("real");

            //
            // Relationships

            //builder.HasOne(t => t.Order).WithMany(t => t.Details).HasForeignKey("OrderID");
            builder.HasOne(t => t.Product).WithMany().HasForeignKey("ProductID");

        }
    }
}
