using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.Dtos;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IIndividualCrudAppService
    {
        Task<IndividualDto> CreateIndividualAsync(NewIndividualDto dto);
    }
}