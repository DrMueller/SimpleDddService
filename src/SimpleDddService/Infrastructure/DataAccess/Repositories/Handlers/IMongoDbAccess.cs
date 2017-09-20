using MongoDB.Driver;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;

namespace SimpleDddService.Infrastructure.DataAccess.Repositories.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot;
    }
}