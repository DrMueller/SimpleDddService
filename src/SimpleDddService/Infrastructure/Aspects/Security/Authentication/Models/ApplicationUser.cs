using System.Collections.Generic;
using SimpleDddService.Infrastructure.DomainExtensions.Invariance;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models
{
    public class ApplicationUser
    {
        public ApplicationUser(string userIdentifier, IReadOnlyCollection<ApplicationClaim> claims)
        {
            Guard.StringNotNullorEmpty(() => userIdentifier);
            Guard.ObjectNotNull(() => claims);

            UserIdentifier = userIdentifier;
            Claims = claims;
        }

        public IReadOnlyCollection<ApplicationClaim> Claims { get; }
        public string UserIdentifier { get; }
    }
}