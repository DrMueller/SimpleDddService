using System.Net.Http;

namespace SimpleDddService.Infrastructure.RestProxy.Services.Handlers.Implementation
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient()
        {
            var result = new HttpClient();
            return result;
        }
    }
}