using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices
{
    public interface ISignInAppService
    {
        Task<SignInResult> SignInAsync(string userName, string password);
    }
}