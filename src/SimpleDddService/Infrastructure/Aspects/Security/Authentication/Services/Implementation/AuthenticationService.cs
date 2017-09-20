using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApplicationUserFactory _applicationUserFactory;
        private readonly IUserLogInHandler _userLogInHandler;

        public AuthenticationService(IApplicationUserFactory applicationUserFactory, IUserLogInHandler userLogInHandler)
        {
            _applicationUserFactory = applicationUserFactory;
            _userLogInHandler = userLogInHandler;
        }

        public async Task<ApplicationUser> AuthenticateAsync(AuthenticationRequest authenticationRequest)
        {
            var userIsAuthenticated = await _userLogInHandler.LogInUserAsync(authenticationRequest.UserIdentifier, authenticationRequest.UserIdentifier);
            var result = await _applicationUserFactory.CreateUserAsync(authenticationRequest.UserIdentifier, userIsAuthenticated);

            return result;
        }
    }
}