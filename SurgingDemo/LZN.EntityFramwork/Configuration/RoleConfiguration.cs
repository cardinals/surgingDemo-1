using LZN.Core.Model;
using LZN.EntityFramwork.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZN.EntityFramwork.Configuration
{
    public class RoleConfiguration : EntityMappingConfiguration<Role>
    {
        public override void Map(EntityTypeBuilder<Role> b)
        {
            b.ToTable("Roles");
            b.HasKey(p => p.Id);
            b.Property(p => p.Name).IsRequired().HasMaxLength(64);
            b.Property(p => p.IsDelete);
            b.Property(p => p.CreateDate);
        }
    }
}
