using System;
using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;
using SimpleDddService.Infrastructure.Integration.RestProxy.Models;
using SimpleDddService.Infrastructure.Integration.RestProxy.Services;
using SimpleDddService.Infrastructure.LanguageExtensions.Maybes;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices.Implementation
{
    public class ExternalCallAppService : IExternalCallAppService
    {
        private readonly IRestProxy _restProxy;

        public ExternalCallAppService(IRestProxy restProxy)
        {
            _restProxy = restProxy;
        }

        public async Task<Maybe<PostAppDto>> GetOnePostAsync(bool getResult)
        {
            if (!getResult)
            {
                return MaybeFactory.CreateNone<PostAppDto>();
            }

            var baseUri = new Uri("https://jsonplaceholder.typicode.com/posts/");
            const string ResourcePath = "1";

            var restApiCall = new RestApiCall(baseUri, ResourcePath, RestApiCallMethodType.Get);
            var returnedPostAppDto = await _restProxy.PerformApiCallAsync<PostAppDto>(restApiCall);

            if (returnedPostAppDto == null)
            {
                return MaybeFactory.CreateNone<PostAppDto>();
            }

            return MaybeFactory.CreateSome(returnedPostAppDto);
        }
    }
}