namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices
{
    public interface IJtwTokenAppFactory
    {
        string CreateSerializedJtwToken(string userName);
    }
}