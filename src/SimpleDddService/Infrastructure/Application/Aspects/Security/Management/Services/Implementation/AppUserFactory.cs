using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services.Implementation
{
    public class AppUserFactory : IAppUserFactory
    {
        public AppUser Create(string userName)
        {
            return new AppUser(userName);
        }
    }
}