using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services
{
    public interface IAppUserFactory
    {
        AppUser Create(string userName);
    }
}