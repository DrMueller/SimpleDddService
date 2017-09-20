using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Domain.Factories;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;
using SimpleDddService.Infrastructure.ServiceProvisioning;

namespace SimpleDddService.Areas.IndividualManagement.Application.Dtos.Profiles
{
    public class AddressDtoProfile : Profile
    {
        public AddressDtoProfile()
        {
            CreateMap<Address, AddressDto>();

            CreateMap<AddressDto, Address>()
                .ConvertUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        var addressFactory = ProvisioningServiceSingleton.Instance.GetService<IAddressFactory>();

                        var addressType = mapper.Map<AddressType>(dto.AddressType);
                        var result = addressFactory.CreateAddress(addressType, dto.Street, dto.Zip, dto.City);
                        return result;
                    });
        }
    }
}