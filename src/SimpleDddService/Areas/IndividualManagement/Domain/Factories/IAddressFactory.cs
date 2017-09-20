using SimpleDddService.Areas.IndividualManagement.Domain.Models;

namespace SimpleDddService.Areas.IndividualManagement.Domain.Factories
{
    public interface IAddressFactory
    {
        Address CreateAddress(AddressType addressType, string street, string zip, string city);
    }
}