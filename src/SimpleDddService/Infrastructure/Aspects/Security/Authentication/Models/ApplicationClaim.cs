using SimpleDddService.Infrastructure.DomainExtensions.Invariance;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models
{
    public class ApplicationClaim
    {
        public ApplicationClaim(string claimType, string claimValue)
        {
            Guard.StringNotNullorEmpty(() => claimType);

            ClaimType = claimType;
            ClaimValue = claimValue ?? string.Empty;
        }

        public string ClaimType { get; }
        public string ClaimValue { get; }

        public override string ToString()
        {
            var claimValue = ClaimValue;
            return $"{ClaimType}:{claimValue}";
        }
    }
}