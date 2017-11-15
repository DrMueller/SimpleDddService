using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.IdentityIntegration.Services
{
    public interface IAppUserCrudService
    {
        Task<AppUser> CreateAppUserAsync(AppUser appUser);
    }
}