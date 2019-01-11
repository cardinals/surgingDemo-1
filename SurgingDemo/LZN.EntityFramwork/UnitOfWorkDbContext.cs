
using MicroService.Core;
using MicroService.Data.Configuration;
using MicroService.Data.Mapping;
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
            var assemblyName = ConfigManager.GetValue<string>("SqlConfig:EntityConfigurationAssembly");
            modelBuilder.AddEntityConfigurationsFromAssembly(GetAssembly(assemblyName));

        

            //var assemblies = GetAssembly(Assembly.GetExecutingAssembly().Location);

            //var currentAssemblies = CreateModulesByFilter(assemblies, REPOSITORY);

            //var typesToRegister = new List<Type>();

            //foreach (var currentAssembly in currentAssemblies)
            //{
            //    typesToRegister.AddRange(currentAssembly.GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null));
            //}

            //foreach (var type in typesToRegister)

            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);

            //    modelBuilder.ApplyConfiguration(configurationInstance);

            //}

        }
        public const string REPOSITORY = @"^MicroServer\.(.*\.)?Entitiy";
        public static List<Assembly> CreateModulesByFilter(List<Assembly> assemblies, string filter)
        {
            List<Assembly> modules = new List<Assembly>();
            modules.AddRange(
                assemblies.Where(item => Regex.IsMatch(Path.GetFileNameWithoutExtension(item.CodeBase), filter)));
            return modules;
        }
        //public static List<Assembly> GetAssembly(string path)
        //{
        //    //dynamic type = (new Program()).GetType();
        //    string currentDirectory = Path.GetDirectoryName(path);
        //    var files = Directory.GetFiles(currentDirectory, "*.dll");
        //    var assemblys = new List<Assembly>();

        //    foreach (var file in files)
        //    {
        //        assemblys.Add(Assembly.LoadFrom(file));
        //    }

        //    return assemblys;
        //}
        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }
    }
}
