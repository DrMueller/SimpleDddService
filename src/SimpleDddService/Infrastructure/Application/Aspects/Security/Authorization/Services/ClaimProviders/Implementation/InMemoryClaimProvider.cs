using System.Collections.Generic;
using System.Security.Claims;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authorization.Services.ClaimProviders.Implementation
{
    public class InMemoryClaimProvider : IClaimProvider
    {
        public IReadOnlyCollection<Claim> ProvideClaimsByUserId(string userId)
        {
            var result = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userId),
                new Claim("TimeReportingClaim", "Tra")
            };

            return result;
        }
    }
}