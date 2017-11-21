using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Initialization.Services;
using SimpleDddService.Infrastructure.Application.Initialization.Handlers;
using SimpleDddService.Infrastructure.Application.Settings.Models;
using SimpleDddService.Infrastructure.ServiceProvisioning;
using StructureMap;

namespace SimpleDddService.Infrastructure.Application.Initialization
{
    internal static class ServiceInitialization
    {
        internal static IServiceProvider InitializeServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddAutoMapper();
            InitializeAppSettings(services, configuration);
            InitializeCors(services);
            InitializeSecurity(services);

            services.AddMvc();

            var result = CreateServiceProvider(services);
            return result;
        }

        private static IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            var container = ContainerInitialization.CreateInitializedContainer();

            container.Populate(services);
            var result = container.GetInstance<IServiceProvider>();
            var provisioningService = result.GetService<IProvisioningService>();

            ProvisioningServiceSingleton.Initialize(provisioningService);

            return result;
        }

        private static void InitializeAppSettings(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionName));
            services.AddSingleton(configuration);
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

        private static void InitializeSecurity(IServiceCollection services)
        {
            // TODO: There has to be a better way?
            var servicesProvider = CreateServiceProvider(services);
            var securityInitializationService = servicesProvider.GetService<ISecurityInitializationService>();

            securityInitializationService.InitializeSecurity(services);
        }
    }
}