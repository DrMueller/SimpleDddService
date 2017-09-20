using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleDddService.Infrastructure.ServiceProvisioning;
using StructureMap;

namespace SimpleDddService.Infrastructure.Application.Initialization.Handlers
{
    internal static class IocInitialization
    {
        internal static IServiceProvider InitializeIoc(IServiceCollection services)
        {
            var container = ContainerInitialization.CreateInitializedContainer();
            container.Populate(services);

            var result = container.GetInstance<IServiceProvider>();
            var provisioningService = result.GetService<IProvisioningService>();
            ProvisioningServiceSingleton.Initialize(provisioningService);

            return result;
        }
    }
}