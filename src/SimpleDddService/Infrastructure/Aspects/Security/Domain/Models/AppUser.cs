using SimpleDddService.Infrastructure.DomainExtensions.Invariance;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;

namespace SimpleDddService.Infrastructure.Aspects.Security.Domain.Models
{
    public class AppUser : AggregateRoot
    {
        public AppUser(string userName)
        {
            Guard.StringNotNullOrEmpty(() => userName);

            UserName = userName;
        }

        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; private set; }
    }
}