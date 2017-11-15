namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppDtos
{
    public class AuthenticationRequestAppDto
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}