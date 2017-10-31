using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppDtos.Profiles
{
    public class AddressTypeAppDtoProfile : Profile
    {
        private readonly IDictionary<AddressTypeAppDto, AddressType> _map = new Dictionary<AddressTypeAppDto, AddressType>
        {
            { AddressTypeAppDto.Business, AddressType.Business },
            { AddressTypeAppDto.Private, AddressType.Private }
        };

        public AddressTypeAppDtoProfile()
        {
            CreateMap<AddressType, AddressTypeAppDto>().ConvertUsing(
                gender =>
                {
                    return _map.First(f => f.Value == gender).Key;
                });

            CreateMap<AddressTypeAppDto, AddressType>().ConvertUsing(dto => _map[dto]);
        }
    }
}