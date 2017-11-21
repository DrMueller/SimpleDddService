namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Dtos
{
    public class SignInResultDto
    {
        public string SerializedJwtToken { get; set; }
        public bool Succeeded { get; set; }
    }
}