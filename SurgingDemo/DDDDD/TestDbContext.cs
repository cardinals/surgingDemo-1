using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDDD
{
   public class TestDbContext: DbContext
    {
        public DbSet<OrderInfo> OrderInfos { get; set; }

        public TestDbContext(DbContextOptions<DbContext> Options) : base(Options)
        {
        }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Model
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseMySQL("server=112.74.59.197;uid=root;pwd=LZN520cy&xnn;database=OrderInfo1;");
        }

    }
}
