using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Api.Models;

namespace Northwind.Api.Db.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            //
            // Properties
            builder.Property(t => t.CompanyName).HasMaxLength(40).IsRequired();
            builder.Property(t => t.ContactName).HasMaxLength(30);
            builder.Property(t => t.ContactTitle).HasMaxLength(30);

            //
            // Table & Column Mappings
            builder.ToTable("Customers");
            
            builder.Property(t => t.Id).HasColumnName("CustomerID");
            builder.Property(t => t.CompanyName).HasColumnName("CompanyName");
            builder.Property(t => t.ContactName).HasColumnName("ContactName");

            builder.Property(t => t.Phone).HasColumnName("Phone");
            builder.Property(t => t.Fax).HasColumnName("Fax");
            
            //
            // Relationships

            builder.OwnsOne(customer => customer.Address, ca => {
                //
                // Properties
                ca.Property(p => p.Street1).HasMaxLength(60);
                ca.Property(p => p.City).HasMaxLength(15);
                ca.Property(p => p.Region).HasMaxLength(15);
                ca.Property(p => p.PostalCode).HasMaxLength(10);

                //
                // Table & Column Mappings
                ca.Property(p => p.Street1).HasColumnName("Address");
                ca.Property(p => p.City).HasColumnName("City");
                ca.Property(p => p.Region).HasColumnName("Region");
                ca.Property(p => p.PostalCode).HasColumnName("PostalCode");
            });
        }
    }
}