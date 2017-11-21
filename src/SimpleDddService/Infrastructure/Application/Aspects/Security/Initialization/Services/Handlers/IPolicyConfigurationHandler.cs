using Microsoft.Extensions.DependencyInjection;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Initialization.Services.Handlers
{
    public interface IPolicyConfigurationHandler
    {
        void InitializePolicyAuthorization(IServiceCollection services);
    }
}