using System.Collections.Generic;
using System.Security.Authentication;
using MongoDB.Driver;
using SimpleDddService.Infrastructure.Application.Settings.Models;
using SimpleDddService.Infrastructure.Application.Settings.Services;
using SimpleDddService.Infrastructure.DataAccess.DataMapping;

namespace SimpleDddService.Infrastructure.DataAccess.Repositories.Handlers.Implemention
{
    public class MongoClientFactory : IMongoClientFactory
    {
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoClientFactory(IAppSettingsProvider appSettingsProvider, IDataMappingInitializationService dataMappingInitializationService)
        {
            dataMappingInitializationService.AssureMappingsAreInitialized();
            _mongoDbSettings = appSettingsProvider.GetAppSettings().MongoDbSettings;
        }

        public MongoClient Create()
        {
            var clientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress(_mongoDbSettings.Host, _mongoDbSettings.Port),
                UseSsl = _mongoDbSettings.UseSsl
            };

            if (clientSettings.UseSsl)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }

            var identity = new MongoInternalIdentity(_mongoDbSettings.DatabaseName, _mongoDbSettings.UserName);
            var evidence = new PasswordEvidence(_mongoDbSettings.Password);
            clientSettings.Credentials = new List<MongoCredential>
            {
                new MongoCredential("SCRAM-SHA-1", identity, evidence)
            };

            var mongoClient = new MongoClient(clientSettings);
            return mongoClient;
        }
    }
}