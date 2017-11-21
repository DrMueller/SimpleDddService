using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Dtos;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Web
{
    [AllowAnonymous]
    [Route("api/Security/Management/[controller]")]
    public class AppUserController : Controller
    {
        private readonly IAppUserUserManagerProxy _appUserUserManagerProxy;

        public AppUserController(IAppUserUserManagerProxy appUserUserManagerProxy)
        {
            _appUserUserManagerProxy = appUserUserManagerProxy;
        }

        [HttpGet("Claims")]
        [Authorize("")]
        public IActionResult GetClaims()
        {
            var claims = User.Claims.Select(f => "Type: " + f.Type + ", Value: " + f.Value).ToList();

            return Ok(claims);
        }

        [HttpPost]
        public async Task<IActionResult> PostApplicationUserAsync([FromBody] CreateAppUserDto dto)
        {
            var identityResult = await _appUserUserManagerProxy.CreateAppUserAsync(dto);
            return Ok(identityResult);
        }
    }
}