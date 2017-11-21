using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Dtos;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services
{
    public interface IAppUserUserManagerProxy
    {
        Task<IdentityResult> CreateAppUserAsync(CreateAppUserDto dto);
    }
}