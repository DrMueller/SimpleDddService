using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using SimpleDddService.Infrastructure.DataAccess.DataMapping;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;

namespace SimpleDddService.Infrastructure.DomainExtensions.Mappers
{
    public class AggregateRootDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<AggregateRoot>(
                f =>
                {
                    f.AutoMap();
                    f.MapIdMember(c => c.Id).SetIdGenerator(new StringObjectIdGenerator());
                    f.MapMember(c => c.AggregateTypeName);
                });
        }
    }
}