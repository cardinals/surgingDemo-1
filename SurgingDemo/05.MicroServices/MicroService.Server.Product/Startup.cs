﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using MicroService.EntityFramwork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Surging.Core.Caching.Configurations;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.EventBusRabbitMQ.Configurations;
using AutoMapper;
using MicroService.EntityFramwork.SqlServer;

namespace MicroService.Server.Product
{
    public class Startup
    {
        public Startup(IConfigurationBuilder config)
        {
          ConfigureEventBus(config);
          //  ConfigureCache(config);
        }

        public IContainer ConfigureServices(ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            services.AddDbContext<SqlServerDbContext>(opt =>
            {

            });
            services.AddAutoMapper();
            services.AddScoped<IUnitOfWorkDbContext, SqlServerDbContext>();
            ConfigureLogging(services);
            builder.Populate(services);
            //依赖注入
            builder.RegisterModule<DefaultModuleRegister>();
            ServiceLocator.Current = builder.Build();
            return ServiceLocator.Current;
        }

        public void Configure(IContainer app)
        {
   
        }

        #region 私有方法
        /// <summary>
        /// 配置日志服务
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureLogging(IServiceCollection services)
        {
           // services.AddLogging();
        }

        private static void ConfigureEventBus(IConfigurationBuilder build)
        {
            build
            .AddEventBusFile("eventBusSettings.json", optional: false);
        }

        /// <summary>
        /// 配置缓存服务
        /// </summary>
        private void ConfigureCache(IConfigurationBuilder build)
        {
            build
              .AddCacheFile("cacheSettings.json", optional: false);
        }
        #endregion

    }
}
