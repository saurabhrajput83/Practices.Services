﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practices.API.DAL.Main;

namespace Practices.API.Migrations
{
    [DbContext(typeof(PracticeDbContext))]
    [Migration("20220605065650_1.0")]
    partial class _10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Practices.API.DAL.Entities.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BrandId")
                        .UseIdentityColumn();

                    b.Property<string>("BrandDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BrandDescription");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BrandName");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.HasKey("BrandId");

                    b.ToTable("practice_t_Brand");
                });

            modelBuilder.Entity("Practices.API.DAL.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentId")
                        .UseIdentityColumn();

                    b.Property<string>("DepartmentDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DepartmentDescription");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DepartmentName");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.HasKey("DepartmentId");

                    b.ToTable("practice_t_Department");
                });

            modelBuilder.Entity("Practices.API.DAL.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductId")
                        .UseIdentityColumn();

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("BrandId");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ListPrice");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProductDescription");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProductName");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("SellingPrice");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("practice_t_Product");
                });

            modelBuilder.Entity("Practices.API.DAL.Entities.Product", b =>
                {
                    b.HasOne("Practices.API.DAL.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practices.API.DAL.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
