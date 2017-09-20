using System.Threading.Tasks;
using SimpleDddService.Infrastructure.RestProxy.Models;

namespace SimpleDddService.Infrastructure.RestProxy.Services
{
    public interface IRestProxy
    {
        Task<T> PerformApiCallAsync<T>(RestApiCall restApiCall);
    }
}