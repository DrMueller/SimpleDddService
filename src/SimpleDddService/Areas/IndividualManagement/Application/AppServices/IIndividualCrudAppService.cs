using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IIndividualCrudAppService
    {
        Task<IndividualAppDto> CreateIndividualAsync(NewIndividualAppDto dto);

        Task<IndividualAppDto> UpdateIndividualAsync(IndividualAppDto dto);

        Task DeleteIndividualAsync(string individualId);
    }
}