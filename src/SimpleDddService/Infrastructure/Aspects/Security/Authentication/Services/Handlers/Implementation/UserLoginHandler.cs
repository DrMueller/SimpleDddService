using System.Threading.Tasks;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers.Implementation
{
    public class UserLogInHandler : IUserLogInHandler
    {
        public Task<bool> LogInUserAsync(string userIdentifier, string password)
        {
            // Check against AD or so
            var loginOk = userIdentifier == "mmu" && password == "tra";
            return Task.FromResult(loginOk);
        }
    }
}