using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Dtos;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Services
{
    public interface ISignInService
    {
        Task<SignInResultDto> SignInAsync(AuthenticationRequestDto authenticationRequestDto);
    }
}