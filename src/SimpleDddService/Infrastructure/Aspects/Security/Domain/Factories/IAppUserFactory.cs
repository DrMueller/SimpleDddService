using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Domain.Factories
{
    public interface IAppUserFactory
    {
        AppUser Create(string userName);
    }
}