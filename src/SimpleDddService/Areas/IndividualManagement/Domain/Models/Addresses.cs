using System.Collections.Generic;
using System.Linq;

namespace SimpleDddService.Areas.IndividualManagement.Domain.Models
{
    public class Addresses
    {
        private List<Address> _addressList;

        public Addresses()
        {
            _addressList = new List<Address>();
        }

        public IReadOnlyCollection<Address> Entries => _addressList;

        public void AddOrUpdateAddress(Address address)
        {
            var foundEntry = _addressList.FirstOrDefault(f => f == address);
            if (foundEntry != null)
            {
                _addressList.Remove(foundEntry);
            }

            _addressList.Add(address);
        }
    }
}