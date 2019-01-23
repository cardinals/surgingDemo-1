using MicroService.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Entity.Order.Configuration
{
  public  class OrderConfigruation: EntityMappingConfiguration<OrderInfo>
    {
        public override void Map(EntityTypeBuilder<OrderInfo> b)
        {
            b.ToTable("OrderInfos")
                  .HasKey(p => p.Id);
            b.Property(p => p.OrderNumber).IsRequired().HasMaxLength(128);
            b.Property(p => p.TotalMoney).IsRequired();
            b.Property(p => p.UserId).IsRequired().HasMaxLength(36);
            b.Property(p => p.Status).IsRequired();
            b.Property(p => p.ExpireTime).IsRequired();
            b.Property(p => p.IsDelete);
            b.Property(p => p.CreateDate);
        }
    }
}
