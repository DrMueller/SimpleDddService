using Microsoft.IdentityModel.Tokens;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Factories
{
    public interface ISecurityKeyFactory
    {
        SecurityKey CreateSecurityKey();
    }
}