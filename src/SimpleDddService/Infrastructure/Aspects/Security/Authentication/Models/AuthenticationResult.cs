using SimpleDddService.Infrastructure.DomainExtensions.Invariance;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models
{
    public class AuthenticationResult
    {
        public AuthenticationResult(bool authenticationAccepted, ApplicationUser applicationUser)
        {
            if (authenticationAccepted)
            {
                Guard.ObjectNotNull(() => applicationUser);
            }

            ApplicationUser = applicationUser;
            AuthenticationAccepted = authenticationAccepted;
        }

        public ApplicationUser ApplicationUser { get; }
        public bool AuthenticationAccepted { get; }
    }
}