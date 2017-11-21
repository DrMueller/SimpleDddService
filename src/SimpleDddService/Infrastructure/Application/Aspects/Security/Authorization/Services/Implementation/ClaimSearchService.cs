using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Authorization.Services.ClaimProviders;
using SimpleDddService.Infrastructure.ServiceProvisioning;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authorization.Services.Implementation
{
    public class ClaimSearchService : IClaimSearchService
    {
        private readonly IProvisioningService _provisioningService;

        public ClaimSearchService(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public IReadOnlyCollection<Claim> SearchClaimsByUserId(string userId)
        {
            var claimProviders = _provisioningService.GetAllServices<IClaimProvider>();
            var allClaims = claimProviders.SelectMany(f => f.ProvideClaimsByUserId(userId));

            var result = allClaims.ToList();
            return result;
        }
    }
}