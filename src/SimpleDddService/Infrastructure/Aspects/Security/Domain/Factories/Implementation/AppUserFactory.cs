using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Domain.Factories.Implementation
{
    public class AppUserFactory : IAppUserFactory
    {
        public AppUser Create(string userName)
        {
            return new AppUser(userName);
        }
    }
}