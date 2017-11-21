namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Dtos
{
    public class AuthenticationRequestDto
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}