using Microsoft.Extensions.DependencyInjection;

namespace SimpleDddService.Infrastructure.Aspects.Security.Initialization
{
    public interface ISecurityInitializationService
    {
        void InitializeSecurity(IServiceCollection services);
    }
}