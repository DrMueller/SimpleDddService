using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Dtos;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Services.Implementation
{
    public class SignInService : ISignInService
    {
        private readonly IJtwTokenFactory _jwtTokenAppFactory;
        private readonly SignInManager<AppUser> _signInManager;

        public SignInService(SignInManager<AppUser> signInManager, IJtwTokenFactory jwtTokenAppFactory)
        {
            _signInManager = signInManager;
            _jwtTokenAppFactory = jwtTokenAppFactory;
        }

        public async Task<SignInResultDto> SignInAsync(AuthenticationRequestDto authenticationRequestDto)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(authenticationRequestDto.UserName, authenticationRequestDto.Password, true, false);
            var serializedJwtToken = string.Empty;

            if (signInResult.Succeeded)
            {
                serializedJwtToken = await _jwtTokenAppFactory.CreateSerializedJtwTokenAsync(authenticationRequestDto.UserName);
            }

            var result = new SignInResultDto
            {
                SerializedJwtToken = serializedJwtToken,
                Succeeded = signInResult.Succeeded
            };

            return result;
        }
    }
}