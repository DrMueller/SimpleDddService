using Microsoft.IdentityModel.Tokens;

namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices
{
    public interface ISecurityKeyAppFactory
    {
        SecurityKey CreateSecurityKey();
    }
}