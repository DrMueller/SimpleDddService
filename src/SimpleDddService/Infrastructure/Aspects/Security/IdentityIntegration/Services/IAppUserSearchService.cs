using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;
using SimpleDddService.Infrastructure.LanguageExtensions.Maybes;

namespace SimpleDddService.Infrastructure.Aspects.Security.IdentityIntegration.Services
{
    public interface IAppUserSearchService
    {
        Task<Maybe<AppUser>> SearchByNormalizedUserName(string normalizedUserName);

        Task<Maybe<AppUser>> SearchByIdAsync(string userId);
    }
}