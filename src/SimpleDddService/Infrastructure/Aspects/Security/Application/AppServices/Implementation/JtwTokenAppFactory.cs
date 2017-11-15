using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices.Implementation
{
    public class JtwTokenAppFactory : IJtwTokenAppFactory
    {
        private readonly ISecurityKeyAppFactory _securityKeyFactory;

        public JtwTokenAppFactory(ISecurityKeyAppFactory securityKeyFactory)
        {
            _securityKeyFactory = securityKeyFactory;
        }

        public string CreateSerializedJtwToken(string userName)
        {
            var secretKey = _securityKeyFactory.CreateSecurityKey();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName)
            };

            var jwtHeader = new JwtHeader(new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));
            var jwtPayload = new JwtPayload(claims);
            var token = new JwtSecurityToken(jwtHeader, jwtPayload);

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}