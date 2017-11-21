using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Factories;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services.Implementation;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Services.Implementation
{
    public class JtwTokenFactory : IJtwTokenFactory
    {
        private readonly ISecurityKeyFactory _securityKeyFactory;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUserFactory _appUserFactory;

        public JtwTokenFactory(ISecurityKeyFactory securityKeyFactory, UserManager<AppUser> userManager, AppUserFactory appUserFactory)
        {
            _securityKeyFactory = securityKeyFactory;
            _userManager = userManager;
            _appUserFactory = appUserFactory;
        }

        public async Task<string> CreateSerializedJtwTokenAsync(string userName)
        {
            var secretKey = _securityKeyFactory.CreateSecurityKey();
            var appUser = _appUserFactory.Create(userName);

            var claims = await _userManager.GetClaimsAsync(appUser);

            var jwtHeader = new JwtHeader(new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));
            var jwtPayload = new JwtPayload(claims);
            var token = new JwtSecurityToken(jwtHeader, jwtPayload);

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}