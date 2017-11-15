using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices
{
    public interface IAppUserManagerService
    {
        Task<IdentityResult> CreateAppUserAsync(string userName, string password);
    }
}