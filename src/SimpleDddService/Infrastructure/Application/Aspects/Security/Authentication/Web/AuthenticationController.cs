using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Dtos;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Services;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Web
{
    [AllowAnonymous]
    [Route("api/Security/Authentication/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly ISignInService _signInService;

        public AuthenticationController(ISignInService signInService)
        {
            _signInService = signInService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthenticationRequestDto authenticationRequestDto)
        {
            var signInResult = await _signInService.SignInAsync(authenticationRequestDto);
            return Ok(signInResult);
        }
    }
}