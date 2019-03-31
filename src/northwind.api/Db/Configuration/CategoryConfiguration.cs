using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Api.Models;

namespace Northwind.Api.Db.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //
            // Primary Key
            builder.HasKey(t => t.Id);

            //
            // Properties
            builder.Property(t => t.Name).HasMaxLength(15).IsRequired();
            
            //
            // Table & Column Mappings
            builder.ToTable("Categories");
            
            builder.Property(t => t.Id).HasColumnName("CategoryID");
            builder.Property(t => t.Name).HasColumnName("CategoryName");
            builder.Property(t => t.Description).HasColumnName("Description");
            builder.Property(t => t.ImageData).HasColumnName("Picture");

            //
            // Relationships
        }
    }
}