using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers.Implementation
{
    public class ApplicationUserFactory : IApplicationUserFactory
    {
        private readonly IApplicationClaimsResolver _authorizationService;

        public ApplicationUserFactory(IApplicationClaimsResolver authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<ApplicationUser> CreateUserAsync(string userIdentifier, bool setClaims)
        {
            IReadOnlyCollection<ApplicationClaim> claims;

            if (setClaims)
            {
                claims = await _authorizationService.GetAllClaimsAsync(userIdentifier);
            }
            else
            {
                claims = new List<ApplicationClaim>();
            }

            var result = new ApplicationUser(userIdentifier, claims);
            return result;
        }
    }
}