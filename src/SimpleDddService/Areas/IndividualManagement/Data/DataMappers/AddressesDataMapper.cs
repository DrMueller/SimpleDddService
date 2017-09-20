using MongoDB.Bson.Serialization;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;
using SimpleDddService.Infrastructure.DataAccess.DataMapping;

namespace SimpleDddService.Areas.IndividualManagement.Data.DataMappers
{
    public class AddressesDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<Addresses>(
                cm =>
                {
                    cm.AutoMap();
                    cm.MapField("_addressList").SetElementName("AddressList");
                    cm.SetIgnoreExtraElements(true);
                });
        }
    }
}