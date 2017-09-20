using System;

namespace SimpleDddService.Infrastructure.RestProxy.Models
{
    public class RestApiCall
    {
        public RestApiCall(Uri baseUri, string resourcePath, RestApiCallMethodType methodType, object body = null)
        {
            ResourcePath = resourcePath;
            MethodType = methodType;
            BaseUri = baseUri;
            Body = body;
        }

        public object Body { get; }
        public RestApiCallMethodType MethodType { get; }
        public string ResourcePath { get; }
        public Uri BaseUri { get; }
    }
}