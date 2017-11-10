using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleDddService.Infrastructure.Integration.RestProxy.Models;
using SimpleDddService.Infrastructure.Integration.RestProxy.Services.Handlers;

namespace SimpleDddService.Infrastructure.Integration.RestProxy.Services.Implementation
{
    public class RestProxy : IRestProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RestProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> PerformApiCallAsync<T>(RestApiCall restApiCall)
        {
            string stringContent;
            var requestUri = new Uri(restApiCall.BaseUri, restApiCall.ResourcePath);

            switch (restApiCall.MethodType)
            {
                case RestApiCallMethodType.Get:
                {
                    stringContent = await SendGetAsync(requestUri);
                    break;
                }
                case RestApiCallMethodType.Post:
                {
                    stringContent = await SendPostAsync(requestUri, restApiCall.Body);
                    break;
                }
                default:
                {
                    throw new NotImplementedException($"API-Call method {restApiCall.MethodType} is not recognized.");
                }
            }

            if (string.IsNullOrEmpty(stringContent) || stringContent == "[]")
            {
                return default(T);
            }

            var result = JsonConvert.DeserializeObject<T>(stringContent);
            return result;
        }

        private async Task<string> SendGetAsync(Uri requestUri)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return responseBody;
                    }

                    var exceptionMessage = $"Could not get data from {requestUri.AbsoluteUri}. Response: {responseBody}";
                    throw new Exception(exceptionMessage);
                }
            }
        }

        private async Task<string> SendPostAsync(Uri requestUri, object body)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var jsonBody = JsonConvert.SerializeObject(body);
                var stringContent = new StringContent(jsonBody);

                using (var response = await httpClient.PostAsync(requestUri, stringContent))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return responseBody;
                    }

                    var exceptionMessage = $"Could not post data to {requestUri.AbsoluteUri}. Response: {responseBody}";
                    throw new Exception(exceptionMessage);
                }
            }
        }
    }
}