using System.Collections.Generic;
using IdentityServer4.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Factories
{
    public static class ClientFactory
    {
        public static IEnumerable<Client> CreateClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credentials Client Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("superSecretPassword".Sha256())
                    },
                    AllowedScopes = new List<string> { "customAPI.read" }
                }
            };
        }
    }
}