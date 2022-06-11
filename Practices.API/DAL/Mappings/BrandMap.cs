using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //Table
            builder.ToTable("practice_t_Brand");
            //Keys
            builder.HasKey(x => x.BrandId);
            //Columns
            builder.Property(x => x.BrandDescription).HasColumnName("BrandDescription");
            builder.Property(x => x.BrandId).HasColumnName("BrandId");
            builder.Property(x => x.BrandName).HasColumnName("BrandName");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            //Relationships
        }
    }
}
