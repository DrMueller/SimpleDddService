using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppDtos.Profiles
{
    public class IndividualGenderAppDtoProfile : Profile
    {
        private readonly IDictionary<IndividualGenderAppDto, IndividualGender> _map = new Dictionary<IndividualGenderAppDto, IndividualGender>
        {
            { IndividualGenderAppDto.Male, IndividualGender.Male },
            { IndividualGenderAppDto.Female, IndividualGender.Female }
        };

        public IndividualGenderAppDtoProfile()
        {
            CreateMap<IndividualGender, IndividualGenderAppDto>().ConvertUsing(
                gender =>
                {
                    return _map.First(f => f.Value == gender).Key;
                });

            CreateMap<IndividualGenderAppDto, IndividualGender>().ConvertUsing(dto => _map[dto]);
        }
    }
}