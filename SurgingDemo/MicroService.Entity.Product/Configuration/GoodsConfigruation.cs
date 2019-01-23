using MicroService.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Entity.Product.Configuration
{
  public  class GoodsConfigruation: EntityMappingConfiguration<Goods>
    {
        public override void Map(EntityTypeBuilder<Goods> b)
        {
            b.ToTable("Goods")
                  .HasKey(p => p.Id);
            b.Property(p => p.Name).IsRequired().HasMaxLength(128);
            b.Property(p => p.StockNum).IsRequired();
            b.Property(p => p.Price).IsRequired();
            b.Property(p => p.CoverImgSrc).IsRequired().HasMaxLength(256);
            b.Property(p => p.Details).IsRequired();
            b.Property(p => p.IsDelete);
            b.Property(p => p.CreateDate);
        }
    }
}
