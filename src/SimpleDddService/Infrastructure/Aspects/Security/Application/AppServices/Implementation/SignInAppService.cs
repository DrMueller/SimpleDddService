using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices.Implementation
{
    public class SignInAppService : ISignInAppService
    {
        private readonly SignInManager<AppUser> _signInManager;

        public SignInAppService(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignInAsync(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return result;
        }
    }
}
