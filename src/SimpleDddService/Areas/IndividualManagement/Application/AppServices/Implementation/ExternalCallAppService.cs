using System;
using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;
using SimpleDddService.Infrastructure.RestProxy.Models;
using SimpleDddService.Infrastructure.RestProxy.Services;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices.Implementation
{
    public class ExternalCallAppService : IExternalCallAppService
    {
        private readonly IRestProxy _restProxy;

        public ExternalCallAppService(IRestProxy restProxy)
        {
            _restProxy = restProxy;
        }

        public async Task<PostAppDto> GetFirstPostAsync()
        {
            var baseUri = new Uri("https://jsonplaceholder.typicode.com/posts/");
            const string ResourcePath = "1";

            var restApiCall = new RestApiCall(baseUri, ResourcePath, RestApiCallMethodType.Get);

            var result = await _restProxy.PerformApiCallAsync<PostAppDto>(restApiCall);
            return result;
        }
    }
}