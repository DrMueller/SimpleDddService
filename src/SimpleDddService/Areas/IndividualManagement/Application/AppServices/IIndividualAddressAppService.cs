using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.Dtos;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IIndividualAddressAppService
    {
        Task<AddressDto> AddOrUpdateAddressAsync(string individualId, AddressDto dto);

        Task<IReadOnlyCollection<AddressDto>> GetAllAddressesAsync(string individualId);
    }
}