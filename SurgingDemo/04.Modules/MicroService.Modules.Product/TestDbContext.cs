using MicroService.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Modules.Product
{
    public class TestDbContext : DbContext
    {
        public DbSet<Goods> Goods { get; set; }

        public TestDbContext()
        {

        }

        public TestDbContext(DbContextOptions<DbContext> dbContextOptions) : base(dbContextOptions)
        {


        }
        protected string GetConnetciton()
        {
            var connectionString = ConfigManager.GetValue<string>("SqlConfig:connectionString");
            return connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnetciton());

        } 
    }
}
