using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;
using SimpleDddService.Infrastructure.ServiceProvisioning;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers.Implementation
{
    public class ApplicationClaimsResolver : IApplicationClaimsResolver
    {
        private readonly IEnumerable<IClaimProvider> _claimProviders;

        public ApplicationClaimsResolver(IProvisioningService provisioningService)
        {
            _claimProviders = provisioningService.GetAllServices<IClaimProvider>();
        }

        public async Task<IReadOnlyCollection<ApplicationClaim>> GetAllClaimsAsync(string userIdentifier)
        {
            var taskArray = _claimProviders.Select(claimProvider => claimProvider.GetClaimsAsync(userIdentifier)).ToArray();
            var allClaimLists = await Task.WhenAll(taskArray);

            var result = allClaimLists.SelectMany(f => f).ToList();
            return result;
        }
    }
}