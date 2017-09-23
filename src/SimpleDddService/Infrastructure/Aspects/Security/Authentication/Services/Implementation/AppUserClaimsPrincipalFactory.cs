using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Implementation
{
    public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, Role>
    {
        private readonly IApplicationClaimsResolver _authorizationService;

        public AppUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        public AppUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, IOptions<IdentityOptions> optionsAccessor, IApplicationClaimsResolver authorizationService) : base(userManager, roleManager, optionsAccessor)
        {
            _authorizationService = authorizationService;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser applicationUser)
        {
            var principal = await base.CreateAsync(applicationUser);
            var applicationClaims = await _authorizationService.GetAllClaimsAsync(applicationUser.UserIdentifier);

            var identity = (ClaimsIdentity)principal.Identity;
            foreach (var appClaim in applicationClaims)
            {
                identity.AddClaim(new Claim(appClaim.ClaimType, appClaim.ClaimValue));
            }

            return principal;
        }
    }
}