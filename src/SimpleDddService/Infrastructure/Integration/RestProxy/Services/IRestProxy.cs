using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Integration.RestProxy.Models;

namespace SimpleDddService.Infrastructure.Integration.RestProxy.Services
{
    public interface IRestProxy
    {
        Task<T> PerformApiCallAsync<T>(RestApiCall restApiCall);
    }
}