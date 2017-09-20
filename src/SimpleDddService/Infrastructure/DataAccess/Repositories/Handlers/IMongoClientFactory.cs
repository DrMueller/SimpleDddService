using MongoDB.Driver;

namespace SimpleDddService.Infrastructure.DataAccess.Repositories.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}