using Microsoft.Extensions.DependencyInjection;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Initialization.Services
{
    public interface ISecurityInitializationService
    {
        void InitializeSecurity(IServiceCollection services);
    }
}