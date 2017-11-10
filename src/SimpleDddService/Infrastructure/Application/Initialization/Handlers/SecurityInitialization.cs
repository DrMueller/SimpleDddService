using Microsoft.Extensions.DependencyInjection;
using SimpleDddService.Infrastructure.Aspects.Security.Factories;
using SimpleDddService.Infrastructure.Aspects.Security.Models;

namespace SimpleDddService.Infrastructure.Application.Initialization.Handlers
{
    internal static class SecurityInitialization
    {
        internal static void InitializeSecurity(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryClients(ClientFactory.CreateClients())
                .AddInMemoryIdentityResources(ResourceFactory.CreateIdentityResources())
                .AddInMemoryApiResources(ResourceFactory.CreateApiResources())
                .AddTestUsers(UserFactory.CreateTestUsers())
                .AddDeveloperSigningCredential();
        }
    }
}