using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IIndividualAddressAppService
    {
        Task<AddressAppDto> AddOrUpdateAddressAsync(string individualId, AddressAppDto dto);

        Task<IReadOnlyCollection<AddressAppDto>> GetAllAddressesAsync(string individualId);
    }
}