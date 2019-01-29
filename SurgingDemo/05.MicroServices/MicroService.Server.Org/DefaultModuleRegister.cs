using Autofac;
using MicroService.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace MicroService.Server.Org
{
   public class DefaultModuleRegister: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var baseType = typeof(IDependency);
          builder.RegisterAssemblyTypes(GetAssembly("MicroService.Application.Org"))
                .Where(t=>baseType.IsAssignableFrom(t)&&t!= baseType)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(GetAssembly("MicroService.Respository.Org"))
              .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
              .AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(GetAssembly("LZN.Core"), GetAssembly("LZN.EntityFramwork"))
            //    .Where(t => t.Name.EndsWith("Respository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(GetAssembly("MicroService.Core"), GetAssembly("MicroService.EntityFramwork"))
                .Where(t => t.Name.EndsWith("ContextBase")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(GetAssembly("LZN.EntityFramwork"))
            //  .Where(t => t.Name.EndsWith("DbContext")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).
            //    Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //注册所有"MyApp.Repository"程序集中的类
            //builder.RegisterAssemblyTypes(GetAssembly("MyApp.Repository")).AsImplementedInterfaces();
        }

        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }
    }
}
