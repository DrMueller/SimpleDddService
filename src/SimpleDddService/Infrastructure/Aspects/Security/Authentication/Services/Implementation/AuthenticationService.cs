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

        public async Task<AuthenticationResult> AuthenticateAsync(AuthenticationRequest authenticationRequest)
        {
            var authenticationAccepted = await _userLogInHandler.LogInUserAsync(authenticationRequest.UserIdentifier, authenticationRequest.Password);
            var user = await _applicationUserFactory.CreateUserAsync(authenticationRequest.UserIdentifier, authenticationAccepted);

            var result = new AuthenticationResult(authenticationAccepted, user);
            return result;
        }
    }
}