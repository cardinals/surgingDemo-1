using MicroService.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Entity.Product.Configuration
{
  public  class PersonConfigruation: EntityMappingConfiguration<Goods>
    {
        public override void Map(EntityTypeBuilder<Goods> b)
        {
            b.ToTable("Goods")
                  .HasKey(p => p.Id);
            b.Property(p => p.Name).IsRequired().HasMaxLength(64);
            b.Property(p => p.IsDelete);
            b.Property(p => p.CreateDate);
        }
    }
}
