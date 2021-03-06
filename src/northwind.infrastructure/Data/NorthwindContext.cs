using Microsoft.EntityFrameworkCore;
using Northwind.Core.Entities;
using Northwind.Infrastructure.Data.Configuration;

namespace Northwind.Infrastructure.Data
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base (options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperConfiguration());
            //
            // Global filter for discontinued products
            // modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);
        }
    }
}

