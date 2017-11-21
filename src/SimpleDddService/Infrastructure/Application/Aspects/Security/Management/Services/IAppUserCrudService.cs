using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services
{
    public interface IAppUserCrudService
    {
        Task<AppUser> CreateAppUserAsync(AppUser appUser);
    }
}