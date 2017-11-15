using SimpleDddService.Infrastructure.DomainExtensions.Invariance;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;

namespace SimpleDddService.Areas.IndividualManagement.Domain.Models
{
    public class Address : Entity
    {
        public Address(AddressType addressType, string street, string zip, string city)
        {
            Guard.StringNotNullOrEmpty(() => street);
            Guard.StringNotNullOrEmpty(() => zip);
            Guard.StringNotNullOrEmpty(() => city);

            AddressType = addressType;
            Street = street;
            Zip = zip;
            City = city;
        }

        public AddressType AddressType { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Zip { get; private set; }
    }
}