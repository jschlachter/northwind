using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Api.Models;

namespace Northwind.Api.Db.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //
            // Primary Key
            builder.HasKey(t => t.Id);

            //
            // Properties
            builder.Property(t => t.CustomerId).HasMaxLength(5);

            //
            // Table & Column Mappings
            builder.ToTable("Orders");

            builder.Property(t => t.Id).HasColumnName("OrderID");
            builder.Property(t => t.CustomerId).HasColumnName("CustomerID");

            //
            // Relationships
            builder.HasOne(t => t.Shipper).WithMany().HasForeignKey("ShipVia");

            builder.OwnsOne(order => order.ShippingAddress, oa => {
                //
                // Properties
                oa.Property(p => p.Street1).HasMaxLength(60);
                oa.Property(p => p.City).HasMaxLength(15);
                oa.Property(p => p.Region).HasMaxLength(15);
                oa.Property(p => p.PostalCode).HasMaxLength(10);
                oa.Property(p => p.Country).HasMaxLength(15);

                //
                // Table & Column Mappings
                oa.Property(p => p.Street1).HasColumnName("ShipAddress");
                oa.Property(p => p.City).HasColumnName("ShipCity");
                oa.Property(p => p.Region).HasColumnName("ShipRegion");
                oa.Property(p => p.PostalCode).HasColumnName("ShipPostalCode");
                oa.Property(p => p.Country).HasColumnName("ShipCountry");
            });
        }
    }
}
