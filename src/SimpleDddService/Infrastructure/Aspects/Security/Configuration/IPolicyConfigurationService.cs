using Microsoft.AspNetCore.Authorization;

namespace SimpleDddService.Infrastructure.Aspects.Security.Configuration
{
    public interface IPolicyConfigurationService
    {
        void ConfigurePolicies(AuthorizationOptions authorizationOptions);
    }
}