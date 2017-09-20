using MongoDB.Driver;
using SimpleDddService.Infrastructure.Application.Settings.Models;
using SimpleDddService.Infrastructure.Application.Settings.Services;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;

namespace SimpleDddService.Infrastructure.DataAccess.Repositories.Handlers.Implemention
{
    public class MongoDbAccess : IMongoDbAccess
    {
        private readonly IMongoClientFactory _mongoClientFactory;
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoDbAccess(IMongoClientFactory mongoClientFactory, IAppSettingsProvider appSettingsProvider)
        {
            _mongoClientFactory = mongoClientFactory;
            _mongoDbSettings = appSettingsProvider.GetAppSettings().MongoDbSettings;
        }

        public IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot
        {
            var db = GetDatabase();
            var result = db.GetCollection<T>(_mongoDbSettings.CollectionName);

            return result;
        }

        private IMongoDatabase GetDatabase()
        {
            var mongoClient = _mongoClientFactory.Create();
            var database = mongoClient.GetDatabase(_mongoDbSettings.DatabaseName);
            return database;
        }
    }
}