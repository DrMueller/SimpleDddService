using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;
using SimpleDddService.Infrastructure.LanguageExtensions.Maybes;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services
{
    public interface IAppUserSearchService
    {
        Task<Maybe<AppUser>> SearchByNormalizedUserName(string normalizedUserName);

        Task<Maybe<AppUser>> SearchByIdAsync(string userId);
    }
}