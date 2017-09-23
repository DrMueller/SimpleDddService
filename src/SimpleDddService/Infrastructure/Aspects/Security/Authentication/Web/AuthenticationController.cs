using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Web
{
    [AllowAnonymous]
    [Route("api/Security/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            SignInManager<ApplicationUser> signInManager)
        {
            _authenticationService = authenticationService;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthenticationRequest authenticationRequest)
        {
            var result = await _authenticationService.AuthenticateAsync(authenticationRequest);
            if (result.AuthenticationAccepted)
            {
                await _signInManager.SignInAsync(result.ApplicationUser, true);
            }

            return Ok(result);
        }
    }
}