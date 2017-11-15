using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleDddService.Infrastructure.Aspects.Security.Initialization.Handlers
{
    public interface IPolicyConfigurationHandler
    {
        void InitializePolicyAuthorization(IServiceCollection services);
    }
}