﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Northwind.Api.Models;

namespace Northwind.Api.Db.Migrations
{
    [DbContext(typeof(NorthwindContext))]
    [Migration("20190331163803_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Northwind.Api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<byte[]>("ImageData")
                        .HasColumnName("Picture");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("CategoryName")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Northwind.Api.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CustomerID");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("CompanyName")
                        .HasMaxLength(40);

                    b.Property<string>("ContactName")
                        .HasColumnName("ContactName")
                        .HasMaxLength(30);

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(30);

                    b.Property<string>("Fax")
                        .HasColumnName("Fax");

                    b.Property<string>("Phone")
                        .HasColumnName("Phone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Northwind.Api.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Extension")
                        .HasColumnName("Extension")
                        .HasMaxLength(4);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(10);

                    b.Property<DateTime>("HireDate")
                        .HasColumnName("HireDate");

                    b.Property<string>("HomePhone")
                        .HasColumnName("HomePhone")
                        .HasMaxLength(24);

                    b.Property<byte[]>("ImageData")
                        .HasColumnName("Photo");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasMaxLength(20);

                    b.Property<string>("Notes")
                        .HasColumnName("Notes");

                    b.Property<string>("PhotoPath")
                        .HasMaxLength(255);

                    b.Property<int?>("ReportsTo");

                    b.Property<string>("Title")
                        .HasColumnName("Title")
                        .HasMaxLength(30);

                    b.Property<string>("TitleOfCourtesy")
                        .HasColumnName("TitleOfCourtesy")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("ReportsTo");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Northwind.Api.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasMaxLength(5);

                    b.Property<int?>("EmployeeId");

                    b.Property<decimal>("Freight");

                    b.Property<DateTime>("OrderDate");

                    b.Property<DateTime>("RequiredDate");

                    b.Property<int?>("ShipVia");

                    b.Property<DateTime>("ShippedDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShipVia");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Northwind.Api.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<float>("Discount")
                        .HasColumnName("Discount")
                        .HasColumnType("real");

                    b.Property<short>("Quantity")
                        .HasColumnName("Quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("money")
                        .HasColumnType("money");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("Order Details");
                });

            modelBuilder.Entity("Northwind.Api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID");

                    b.Property<bool>("Discontinued");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("ProductName")
                        .HasMaxLength(40);

                    b.Property<string>("QuantityPerUnit")
                        .HasColumnName("QuantityPerUnit")
                        .HasMaxLength(20);

                    b.Property<short>("ReorderLevel");

                    b.Property<int?>("SupplierID");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("UnitPrice")
                        .HasColumnType("money");

                    b.Property<short>("UnitsInStock")
                        .HasColumnName("UnitsInStock");

                    b.Property<short>("UnitsOnOrder")
                        .HasColumnName("UnitsOnOrder");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Northwind.Api.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RegionID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("RegionDescription")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Northwind.Api.Models.Shipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ShipperID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("CompanyName")
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .HasColumnName("Phone")
                        .HasMaxLength(24);

                    b.HasKey("Id");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("Northwind.Api.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplierID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("ContactName")
                        .HasMaxLength(30);

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(30);

                    b.Property<string>("Fax")
                        .HasMaxLength(24);

                    b.Property<string>("HomePage");

                    b.Property<string>("Phone")
                        .HasMaxLength(24);

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Northwind.Api.Models.Customer", b =>
                {
                    b.OwnsOne("Northwind.Api.Models.Address", "Address", b1 =>
                        {
                            b1.Property<string>("CustomerId");

                            b1.Property<string>("City")
                                .HasColumnName("City")
                                .HasMaxLength(15);

                            b1.Property<string>("Country");

                            b1.Property<string>("PostalCode")
                                .HasColumnName("PostalCode")
                                .HasMaxLength(10);

                            b1.Property<string>("Region")
                                .HasColumnName("Region")
                                .HasMaxLength(15);

                            b1.Property<string>("Street1")
                                .HasColumnName("Address")
                                .HasMaxLength(60);

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.HasOne("Northwind.Api.Models.Customer")
                                .WithOne("Address")
                                .HasForeignKey("Northwind.Api.Models.Address", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Northwind.Api.Models.Employee", b =>
                {
                    b.HasOne("Northwind.Api.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ReportsTo");

                    b.OwnsOne("Northwind.Api.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnName("City")
                                .HasMaxLength(15);

                            b1.Property<string>("Country")
                                .HasMaxLength(15);

                            b1.Property<string>("PostalCode")
                                .HasColumnName("PostalCode")
                                .HasMaxLength(10);

                            b1.Property<string>("Region")
                                .HasColumnName("Region")
                                .HasMaxLength(15);

                            b1.Property<string>("Street1")
                                .HasColumnName("Address")
                                .HasMaxLength(60);

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.HasOne("Northwind.Api.Models.Employee")
                                .WithOne("Address")
                                .HasForeignKey("Northwind.Api.Models.Address", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Northwind.Api.Models.Order", b =>
                {
                    b.HasOne("Northwind.Api.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Northwind.Api.Models.Shipper", "Shipper")
                        .WithMany()
                        .HasForeignKey("ShipVia");

                    b.OwnsOne("Northwind.Api.Models.Address", "ShippingAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnName("ShipCity")
                                .HasMaxLength(15);

                            b1.Property<string>("Country")
                                .HasColumnName("ShipCountry")
                                .HasMaxLength(15);

                            b1.Property<string>("PostalCode")
                                .HasColumnName("ShipPostalCode")
                                .HasMaxLength(10);

                            b1.Property<string>("Region")
                                .HasColumnName("ShipRegion")
                                .HasMaxLength(15);

                            b1.Property<string>("Street1")
                                .HasColumnName("ShipAddress")
                                .HasMaxLength(60);

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.HasOne("Northwind.Api.Models.Order")
                                .WithOne("ShippingAddress")
                                .HasForeignKey("Northwind.Api.Models.Address", "OrderId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Northwind.Api.Models.OrderDetail", b =>
                {
                    b.HasOne("Northwind.Api.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Northwind.Api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Northwind.Api.Models.Product", b =>
                {
                    b.HasOne("Northwind.Api.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("Northwind.Api.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID");
                });

            modelBuilder.Entity("Northwind.Api.Models.Supplier", b =>
                {
                    b.OwnsOne("Northwind.Api.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("SupplierId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnName("City")
                                .HasMaxLength(15);

                            b1.Property<string>("Country")
                                .HasMaxLength(15);

                            b1.Property<string>("PostalCode")
                                .HasColumnName("PostalCode")
                                .HasMaxLength(10);

                            b1.Property<string>("Region")
                                .HasColumnName("Region")
                                .HasMaxLength(15);

                            b1.Property<string>("Street1")
                                .HasColumnName("Address")
                                .HasMaxLength(60);

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.HasOne("Northwind.Api.Models.Supplier")
                                .WithOne("Address")
                                .HasForeignKey("Northwind.Api.Models.Address", "SupplierId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
