using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MicroService.EntityFramwork;
using MicroService.EntityFramwork.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TestWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       // public static IContainer AutofacContainer;
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlServerDbContext>(opt =>
            {

            });
            services.AddAutoMapper();
            services.AddScoped<IUnitOfWorkDbContext, SqlServerDbContext>();
            //依赖注入
          
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //将Evolution注册到项目中来，实现依赖注入
              var builder = new ContainerBuilder();
              builder.RegisterModule<DefaultModuleRegister>();
               builder.Populate(services);
               var container = builder.Build();
               return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
