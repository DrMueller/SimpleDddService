using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Domain.Factories;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;
using SimpleDddService.Infrastructure.ServiceProvisioning;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppDtos.Profiles
{
    public class IndividualAppDtoProfile : Profile
    {
        public IndividualAppDtoProfile()
        {
            CreateMap<Individual, IndividualAppDto>();

            CreateMap<IndividualAppDto, Individual>()
                .ConvertUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        var individualFactory = ProvisioningServiceSingleton.Instance.GetService<IIndividualFactory>();

                        var gender = mapper.Map<IndividualGender>(dto.Gender);
                        return individualFactory.CreateIndividual(dto.FirstName, dto.LastName, gender, dto.BirthDate);
                    });
        }
    }
}