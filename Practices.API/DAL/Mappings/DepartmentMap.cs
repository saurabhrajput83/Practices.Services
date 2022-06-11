using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Mappings
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Table
            builder.ToTable("practice_t_Department");
            //Keys
            builder.HasKey(x => x.DepartmentId);
            //Columns
            builder.Property(x => x.DepartmentDescription).HasColumnName("DepartmentDescription");
            builder.Property(x => x.DepartmentId).HasColumnName("DepartmentId");
            builder.Property(x => x.DepartmentName).HasColumnName("DepartmentName");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            //Relationships
        }
    }
}
