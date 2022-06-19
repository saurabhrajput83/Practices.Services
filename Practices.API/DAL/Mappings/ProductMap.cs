using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Table
            builder.ToTable("practice_t_Product");
            //Keys
            builder.HasKey(x => x.ProductId);
            //Columns
            builder.Property(x => x.BrandId).HasColumnName("BrandId");
            builder.Property(x => x.DepartmentId).HasColumnName("DepartmentId");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            builder.Property(x => x.ListPrice).HasColumnName("ListPrice").HasColumnType("decimal(18,4)");
            builder.Property(x => x.ProductDescription).HasColumnName("ProductDescription");
            builder.Property(x => x.ProductId).HasColumnName("ProductId");
            builder.Property(x => x.ProductName).HasColumnName("ProductName");
            builder.Property(x => x.Quantity).HasColumnName("Quantity");
            builder.Property(x => x.SellingPrice).HasColumnName("SellingPrice").HasColumnType("decimal(18,4)");
            builder.Property(x => x.ProductImageUrl).HasColumnName("ProductImageUrl");
            builder.Property(x => x.ProductUrl).HasColumnName("ProductUrl");
            //Relationships
        }
    }
}
