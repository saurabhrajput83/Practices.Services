using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practices.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Mappings
{
    public class LineItemMap : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            //Table
            builder.ToTable("practice_t_LineItem");
            //Keys
            builder.HasKey(x => x.LineItemId);
            //Columns
            builder.Property(x => x.LineItemId).HasColumnName("LineItemId");
            builder.Property(x => x.ProductId).HasColumnName("ProductId");
            builder.Property(x => x.Quantity).HasColumnName("Quantity");
            builder.Property(x => x.ShoppingCartId).HasColumnName("ShoppingCartId");
            //Relationships
        }
    }
}
