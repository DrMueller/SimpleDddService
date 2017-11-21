using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;
using SimpleDddService.Infrastructure.DataAccess.Repositories;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services.Implementation
{
    public class AppUserCrudService : IAppUserCrudService
    {
        private readonly IRepository<AppUser> _appUserReposistory;

        public AppUserCrudService(IRepository<AppUser> appUserReposistory)
        {
            _appUserReposistory = appUserReposistory;
        }

        public async Task<AppUser> CreateAppUserAsync(AppUser appUser)
        {
            return await _appUserReposistory.SaveAsync(appUser);
        }
    }
}