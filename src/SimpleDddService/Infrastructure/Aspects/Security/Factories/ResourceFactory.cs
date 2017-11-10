using System.Collections.Generic;
using IdentityServer4.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Factories
{
    public static class ResourceFactory
    {
        public static IEnumerable<ApiResource> CreateApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "customAPI",
                    DisplayName = "Custom API",
                    Description = "Custom API Access",
                    UserClaims = new List<string> { "role" },
                    ApiSecrets = new List<Secret> { new Secret("scopeSecret".Sha256()) },
                    Scopes = new List<Scope>
                    {
                        new Scope("customAPI.read"),
                        new Scope("customAPI.write")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> CreateIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };
        }
    }
}