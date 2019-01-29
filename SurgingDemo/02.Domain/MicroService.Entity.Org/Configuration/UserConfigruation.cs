using MicroService.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroService.Entity.Org.Configuration
{
  public  class UserConfigruation: EntityMappingConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> b)
        {
            b.ToTable("Users")
                  .HasKey(p => p.Id);
            b.Property(p => p.RoleId).IsRequired().HasMaxLength(36);
            b.Property(p => p.Name).IsRequired().HasMaxLength(64);
            b.Property(p => p.Password).IsRequired().HasMaxLength(128);
            b.Property(p => p.PhoneCode).HasMaxLength(16);
            b.Property(p => p.IsDelete);
            b.Property(p => p.CreateDate);
            //b.Property(p => p.Timestamp);//.IsRowVersion();
        }
    }
}
