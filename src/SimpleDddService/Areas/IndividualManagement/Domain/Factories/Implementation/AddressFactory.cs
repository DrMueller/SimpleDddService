using SimpleDddService.Areas.IndividualManagement.Domain.Models;

namespace SimpleDddService.Areas.IndividualManagement.Domain.Factories.Implementation
{
    public class AddressFactory : IAddressFactory
    {
        public Address CreateAddress(AddressType addressType, string street, string zip, string city)
        {
            var result = new Address(addressType, street, zip, city);
            return result;
        }
    }
}