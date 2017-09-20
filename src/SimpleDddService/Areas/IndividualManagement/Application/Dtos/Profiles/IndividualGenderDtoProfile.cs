using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;

namespace SimpleDddService.Areas.IndividualManagement.Application.Dtos.Profiles
{
    public class IndividualGenderDtoProfile : Profile
    {
        private readonly IDictionary<IndividualGenderDto, IndividualGender> _map = new Dictionary<IndividualGenderDto, IndividualGender>
        {
            { IndividualGenderDto.Male, IndividualGender.Male },
            { IndividualGenderDto.Female, IndividualGender.Female }
        };

        public IndividualGenderDtoProfile()
        {
            CreateMap<IndividualGender, IndividualGenderDto>().ConvertUsing(
                gender =>
                {
                    return _map.First(f => f.Value == gender).Key;
                });

            CreateMap<IndividualGenderDto, IndividualGender>().ConvertUsing(dto => _map[dto]);
        }
    }
}