using LZN.Core.Model;
using LZN.EntityFramwork.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZN.EntityFramwork.Configuration
{
  public  class PersonConfigruation: EntityMappingConfiguration<Person>
    {
        public override void Map(EntityTypeBuilder<Person> b)
        {
            b.ToTable("People")
                  .HasKey(p => p.Id);
            b.Property(p => p.RoleId).IsRequired().HasMaxLength(36);
            b.Property(p => p.Name).IsRequired().HasMaxLength(64);
            b.Property(p => p.PhoneCode).HasMaxLength(16);
            b.Property(p => p.IsDelete);
            b.Property(p => p.CreateDate);
        }
    }
}
