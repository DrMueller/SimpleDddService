using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Implementation;
using Xunit;

namespace SimpleDddService.UnitTests.Areas.Infrastructure.Aspects.Security.Authentication
{
    public class AuthenticationServiceUnitTests
    {
        private readonly Mock<IApplicationUserFactory> _applicationUserFactoryMock;
        private readonly AuthenticationService _sut;
        private readonly Mock<IUserLogInHandler> _userLogInHandlerMock;

        public AuthenticationServiceUnitTests()
        {
            _userLogInHandlerMock = new Mock<IUserLogInHandler>();
            _applicationUserFactoryMock = new Mock<IApplicationUserFactory>();
            _sut = new AuthenticationService(_applicationUserFactoryMock.Object, _userLogInHandlerMock.Object);
        }

        [Fact]
        public async Task Authenticating_WithValidCredentials_AddsClaimsForUser()
        {
            // Given
            const string UserIdentifier = "ui";
            var appUser = new ApplicationUser(UserIdentifier, "Username123", new List<ApplicationClaim>());

            var actualUserIdentifier = string.Empty;
            var actualAddClaims = false;

            var authRequest = new AuthenticationRequest
            {
                Password = "pw",
                UserIdentifier = UserIdentifier
            };

            _userLogInHandlerMock.Setup(f => f.LogInUserAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));
            _applicationUserFactoryMock.Setup(f => f.CreateUserAsync(It.IsAny<string>(), It.IsAny<bool>())).Callback<string, bool>(
                (userIdentifier, addClaims) =>
                {
                    actualUserIdentifier = userIdentifier;
                    actualAddClaims = addClaims;
                }).Returns(Task.FromResult(appUser));

            // When
            await _sut.AuthenticateAsync(authRequest);

            // Then
            actualAddClaims.Should().Be(true);
            actualUserIdentifier.Should().Be(UserIdentifier);
        }
    }
}