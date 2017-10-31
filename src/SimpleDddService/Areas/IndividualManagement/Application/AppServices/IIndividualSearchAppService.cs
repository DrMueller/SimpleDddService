using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IIndividualSearchAppService
    {
        Task<IReadOnlyCollection<IndividualAppDto>> GetAllIndividualsAsync();

        Task<IndividualAppDto> GetIndividualByIdAsync(string id);
    }
}