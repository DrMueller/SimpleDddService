using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Factories;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices.Implementation
{
    public class AppUserManagerService : IAppUserManagerService
    {
        private readonly IAppUserFactory _appUserFactory;
        private readonly UserManager<AppUser> _userManager;

        public AppUserManagerService(UserManager<AppUser> userManager, IAppUserFactory appUserFactory)
        {
            _userManager = userManager;
            _appUserFactory = appUserFactory;
        }

        public async Task<IdentityResult> CreateAppUserAsync(string userName, string password)
        {
            var appUser = _appUserFactory.Create(userName);
            var result = await _userManager.CreateAsync(appUser, password);

            return result;
        }
    }
}