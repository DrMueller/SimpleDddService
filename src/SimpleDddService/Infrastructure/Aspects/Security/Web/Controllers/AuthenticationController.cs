using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Infrastructure.Aspects.Security.Application.AppDtos;
using SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices;

namespace SimpleDddService.Infrastructure.Aspects.Security.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/Security/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IJtwTokenAppFactory _jwtTokenAppFactory;
        private readonly ISignInAppService _signInAppService;

        public AuthenticationController(ISignInAppService signInAppService, IJtwTokenAppFactory jwtTokenAppFactory)
        {
            _signInAppService = signInAppService;
            _jwtTokenAppFactory = jwtTokenAppFactory;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthenticationRequestAppDto authenticationRequest)
        {
            var signInResult = await _signInAppService.SignInAsync(authenticationRequest.UserName, authenticationRequest.Password);

            if (signInResult.Succeeded)
            {
                var tokenString = _jwtTokenAppFactory.CreateSerializedJtwToken(authenticationRequest.UserName);
                return Ok(tokenString);
            }

            return BadRequest();
        }
    }
}