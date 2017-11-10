using System.Net.Http;

namespace SimpleDddService.Infrastructure.Integration.RestProxy.Services.Handlers
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}