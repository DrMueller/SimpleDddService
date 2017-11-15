using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices;
using SimpleDddService.Infrastructure.Aspects.Security.Web.WebDtos;

namespace SimpleDddService.Infrastructure.Aspects.Security.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/Security/[controller]")]
    public class AppUserController : Controller
    {
        private readonly IAppUserManagerService _appUserManagerService;

        public AppUserController(IAppUserManagerService appUserManagerService)
        {
            _appUserManagerService = appUserManagerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostApplicationUserAsync([FromBody] CreateApplicationUserDto dto)
        {
            var identityResult = await _appUserManagerService.CreateAppUserAsync(dto.UserName, dto.Password);
            return Ok(identityResult);
        }
    }
}