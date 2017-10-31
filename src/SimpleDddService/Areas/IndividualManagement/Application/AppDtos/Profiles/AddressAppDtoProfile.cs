using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Domain.Factories;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;
using SimpleDddService.Infrastructure.ServiceProvisioning;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppDtos.Profiles
{
    public class AddressAppDtoProfile : Profile
    {
        public AddressAppDtoProfile()
        {
            CreateMap<Address, AddressAppDto>();

            CreateMap<AddressAppDto, Address>()
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