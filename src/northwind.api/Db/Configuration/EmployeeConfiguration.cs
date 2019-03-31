using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Api.Models;

namespace Northwind.Api.Db.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //
            // Primary Key
            builder.HasKey(t => t.Id);

            //
            // Properties
            builder.Property(t => t.LastName).HasMaxLength(20).IsRequired();
            builder.Property(t => t.FirstName).HasMaxLength(10).IsRequired();
            builder.Property(t => t.Title).HasMaxLength(30);
            builder.Property(t => t.TitleOfCourtesy).HasMaxLength(25);
            builder.Property(t => t.HomePhone).HasMaxLength(24);
            builder.Property(t => t.Extension).HasMaxLength(4);
            builder.Property(t => t.PhotoPath).HasMaxLength(255);

            //
            // Table & Column Mappings
            builder.ToTable("Employees");

            builder.Property(t => t.Id).HasColumnName("EmployeeId");
            builder.Property(t => t.LastName).HasColumnName("LastName");
            builder.Property(t => t.FirstName).HasColumnName("FirstName");
            builder.Property(t => t.Title).HasColumnName("Title");
            builder.Property(t => t.TitleOfCourtesy).HasColumnName("TitleOfCourtesy");
            builder.Property(t => t.BirthDate).HasColumnName("BirthDate");
            builder.Property(t => t.HireDate).HasColumnName("HireDate");
            builder.Property(t => t.HomePhone).HasColumnName("HomePhone");
            builder.Property(t => t.Extension).HasColumnName("Extension");
            builder.Property(t => t.ImageData).HasColumnName("Photo");
            builder.Property(t => t.Notes).HasColumnName("Notes");

            //
            // Relationships
            builder.HasOne(t => t.Manager).WithMany().HasForeignKey("ReportsTo");

            builder.OwnsOne(employee => employee.Address, ea => {
                //
                // Properties
                ea.Property(p => p.Street1).HasMaxLength(60);
                ea.Property(p => p.City).HasMaxLength(15);
                ea.Property(p => p.Region).HasMaxLength(15);
                ea.Property(p => p.PostalCode).HasMaxLength(10);
                ea.Property(p => p.Country).HasMaxLength(15);

                //
                // Table & Column Mappings
                ea.Property(p => p.Street1).HasColumnName("Address");
                ea.Property(p => p.City).HasColumnName("City");
                ea.Property(p => p.Region).HasColumnName("Region");
                ea.Property(p => p.PostalCode).HasColumnName("PostalCode");
            });
        }
    }
}
