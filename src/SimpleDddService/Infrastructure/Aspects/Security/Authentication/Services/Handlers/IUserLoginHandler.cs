using System.Threading.Tasks;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers
{
    public interface IUserLogInHandler
    {
        Task<bool> LogInUserAsync(string userIdentifier, string password);
    }
}