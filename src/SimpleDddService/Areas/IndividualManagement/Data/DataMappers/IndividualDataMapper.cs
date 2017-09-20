using MongoDB.Bson.Serialization;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;
using SimpleDddService.Infrastructure.DataAccess.DataMapping;

namespace SimpleDddService.Areas.IndividualManagement.Data.DataMappers
{
    public class IndividualDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<Individual>(
                cm =>
                {
                    cm.AutoMap();
                    cm.MapField("_addresses").SetElementName("Addresses");
                });
        }
    }
}