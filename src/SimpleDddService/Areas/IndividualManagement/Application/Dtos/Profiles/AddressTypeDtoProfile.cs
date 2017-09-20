using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;

namespace SimpleDddService.Areas.IndividualManagement.Application.Dtos.Profiles
{
    public class AddressTypeDtoProfile : Profile
    {
        private readonly IDictionary<AddressTypeDto, AddressType> _map = new Dictionary<AddressTypeDto, AddressType>
        {
            { AddressTypeDto.Business, AddressType.Business },
            { AddressTypeDto.Private, AddressType.Private }
        };

        public AddressTypeDtoProfile()
        {
            CreateMap<AddressType, AddressTypeDto>().ConvertUsing(
                gender =>
                {
                    return _map.First(f => f.Value == gender).Key;
                });

            CreateMap<AddressTypeDto, AddressType>().ConvertUsing(dto => _map[dto]);
        }
    }
}