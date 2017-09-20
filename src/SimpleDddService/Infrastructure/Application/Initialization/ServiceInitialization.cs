using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleDddService.Infrastructure.Application.Initialization.Handlers;
using SimpleDddService.Infrastructure.Application.Settings.Models;

namespace SimpleDddService.Infrastructure.Application.Initialization
{
    internal static class ServiceInitialization
    {
        internal static IServiceProvider InitializeServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            var result = IocInitialization.InitializeIoc(services);

            services.AddMvc();
            InitializeAutoMapper(services);
            InitializeAppSettings(services, configuration);
            InitializeCors(services);
            SecurityInitialization.InitializeSecurity(services);

            return result;
        }

        private static void InitializeAppSettings(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionName));
            services.AddSingleton(configuration);
        }

        private static void InitializeAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper();
        }

        private static void InitializeCors(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "All",
                        builder =>
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials());
                });
        }
    }
}