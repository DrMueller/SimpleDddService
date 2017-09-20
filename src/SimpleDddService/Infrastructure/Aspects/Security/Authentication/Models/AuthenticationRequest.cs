namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models
{
    public class AuthenticationRequest
    {
        public string UserIdentifier { get; set; }
        public string Password { get; set; }
    }
}