
using MicroService.Core;
using MicroService.Data.Configuration;
using MicroService.Data.Constant;
using MicroService.Data.Mapping;
using MicroService.Data.Utilities;
using MicroService.EntityFramwork.Initialize;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Text.RegularExpressions;

namespace MicroService.EntityFramwork
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
            var connectionString = ConfigManager.GetValue<string>("SqlConfig:connectionString");
            optionsBuilder.UseMySQL(connectionString);
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.AddEntityConfigurationsFromAssembly(GetType().Assembly);
            //var assemblyName = ConfigManager.GetValue<string>("SqlConfig:EntityConfigurationAssembly");
            //modelBuilder.AddEntityConfigurationsFromAssembly(AssemblyHelper.GetAssembly(assemblyName));

            var assemblies = AssemblyHelper.GetAssemblyList(Assembly.GetExecutingAssembly().Location);
            var currentAssemblies = AssemblyHelper.CreateModulesByFilter(assemblies, ConstantHelper.REPOSITORY);
            modelBuilder.AddEntityConfigurationsFromAssembly(currentAssemblies[0]);

        }
      

      
    }
}
