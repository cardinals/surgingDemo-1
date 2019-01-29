
using MicroService.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Entity.Order.Configuration
{
    public class OrderDetailConfiguration : EntityMappingConfiguration<OrderDetail>
    {
        public override void Map(EntityTypeBuilder<OrderDetail> b)
        {
            b.ToTable("OrderDetails");
            b.HasKey(p => p.Id);
            b.Property(p => p.OrderId).IsRequired().HasMaxLength(36);
            b.Property(p => p.GoodsId).IsRequired().HasMaxLength(36);
            b.Property(p => p.Price).IsRequired();
            b.Property(p => p.Count).IsRequired();
            b.Property(p => p.Money).IsRequired();
            b.Property(p => p.IsDelete);
            b.Property(p => p.CreateDate);
        }
    }
}
