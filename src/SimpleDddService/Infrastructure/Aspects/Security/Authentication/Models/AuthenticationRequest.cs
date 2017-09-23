namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models
{
    public class AuthenticationRequest
    {
        public string Password { get; set; }
        public string UserIdentifier { get; set; }
    }
}