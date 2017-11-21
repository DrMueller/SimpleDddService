using System.Collections.Generic;
using System.Security.Claims;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authorization.Services.ClaimProviders
{
    public interface IClaimProvider
    {
        IReadOnlyCollection<Claim> ProvideClaimsByUserId(string userId);
    }
}