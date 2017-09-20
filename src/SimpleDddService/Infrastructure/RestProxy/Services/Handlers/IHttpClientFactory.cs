using System.Net.Http;

namespace SimpleDddService.Infrastructure.RestProxy.Services.Handlers
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}