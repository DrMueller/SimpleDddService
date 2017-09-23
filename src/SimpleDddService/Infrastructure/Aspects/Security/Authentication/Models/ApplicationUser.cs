using System.Collections.Generic;
using SimpleDddService.Infrastructure.DomainExtensions.Invariance;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models
{
    public class ApplicationUser
    {
        public ApplicationUser(string userIdentifier, string userName, IReadOnlyCollection<ApplicationClaim> claims)
        {
            Guard.StringNotNullorEmpty(() => userIdentifier);
            Guard.StringNotNullorEmpty(() => userName);
            Guard.ObjectNotNull(() => claims);

            UserIdentifier = userIdentifier;
            UserName = userName;
            Claims = claims;
        }

        public IReadOnlyCollection<ApplicationClaim> Claims { get; }
        public string UserIdentifier { get; }
        public string UserName { get; }
    }
}