﻿using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Bit.Subscription.Domain.Common.Interfaces.Services;
using Bit.Subscription.Infrastructure.Configurations;
using Bit.Subscription.Infrastructure.Contexts;
using Bit.Subscription.Infrastructure.Services.MSMonitor;
using FluentValidation;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using Bit.Subscription.Application.Licence.Querys;
using Bit.Subscription.Domain.Common.Interfaces.Repositories;
using Bit.Subscription.Infrastructure.Persistence.Repositories;

[assembly: FunctionsStartup(typeof(Bit.Client.Api.Startup))]
namespace Bit.Client.Api
{
    public class Startup : FunctionsStartup
    {
        public IConfigurationRoot configuration { get; }

        public Startup()
        {
            var configurationInit = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
            configuration = configurationInit;
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureServices(builder.Services);
        }


        public void ConfigureServices(IServiceCollection services)
        {
           
            MongoConfiguration cosmosDbConfig = configuration.GetSection("MongoDB").Get<MongoConfiguration>();

            services.AddOptions();

            // Add Logging
            services.AddLogging();

            // Add HttpClient
            services.AddHttpClient();

            //Config
            //LoadConfig(services);

            services.AddAutofac();

            //Commands o Queyrs
            services.AddMediatR(typeof(GetAllLicencesQuery).GetTypeInfo().Assembly);

            //Base de datos
            services.AddSingleton<IMongoContext, MongoContext>();

            //Servicios
            services.AddTransient<IMSMonitorService, MSMonitorService>();

            //Repositorios
            services.AddTransient<ILicenceRepository, LicenceRepository>(); 

            //Configuraciones
            services.AddSingleton<IConfiguration>(configuration);
            services.Configure<MongoConfiguration>(
                options =>
                {
                    options.ConnectionString = cosmosDbConfig.ConnectionString;
                    options.Database = cosmosDbConfig.Database;
                }
            );

            //Mapeer
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}