using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestDb
{
    public class DesignTimeDefaultDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
    {
        public TestDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<TestDbContext>();
            // builder = UseSql(builder, GetConnectionString());

            builder.UseMySQL("server=112.74.59.197;uid=root;pwd=LZN520cy&xnn;database=OrderInfo1");
            return (TestDbContext)Activator.CreateInstance(typeof(DbContext), builder.Options);
        }

      
    }
}
