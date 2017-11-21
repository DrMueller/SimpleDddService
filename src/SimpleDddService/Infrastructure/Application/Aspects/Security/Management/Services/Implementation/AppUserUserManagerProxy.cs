using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Dtos;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services.Implementation
{
    public class AppUserUserManagerProxy : IAppUserUserManagerProxy
    {
        private readonly IAppUserFactory _appUserFactory;
        private readonly UserManager<AppUser> _userManager;

        public AppUserUserManagerProxy(UserManager<AppUser> userManager, IAppUserFactory appUserFactory)
        {
            _userManager = userManager;
            _appUserFactory = appUserFactory;
        }

        public async Task<IdentityResult> CreateAppUserAsync(CreateAppUserDto dto)
        {
            var appUser = _appUserFactory.Create(dto.UserName);
            var result = await _userManager.CreateAsync(appUser, dto.Password);

            return result;
        }
    }
}