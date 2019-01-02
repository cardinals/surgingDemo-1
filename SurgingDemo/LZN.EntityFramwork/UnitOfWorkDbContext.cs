
using LZN.EntityFramwork.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZN.EntityFramwork
{
  public  class UnitOfWorkDbContext:DbContext, IUnitOfWorkDbContext
    {


        //public DbSet<LZN.Core.Model.Person> People { get; set; }


       
        public UnitOfWorkDbContext(DbContextOptions<UnitOfWorkDbContext> dbContextOptions):base(dbContextOptions)
        {

            //dbContextOptions.
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=112.74.59.197;uid=root;pwd=LZN520cy&xnn;database=Test;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
