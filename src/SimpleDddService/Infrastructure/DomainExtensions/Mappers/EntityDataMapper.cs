using MongoDB.Bson.Serialization;
using SimpleDddService.Infrastructure.DataAccess.DataMapping;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;

namespace SimpleDddService.Infrastructure.DomainExtensions.Mappers
{
    public class EntityDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<Entity>(
                f =>
                {
                    f.AutoMap();
                    f.MapIdMember(c => c.Id);
                });
        }
    }
}