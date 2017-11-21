using System.Threading.Tasks;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authentication.Services
{
    public interface IJtwTokenFactory
    {
        Task<string> CreateSerializedJtwTokenAsync(string userName);
    }
}