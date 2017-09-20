using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.Dtos;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IIndividualSearchAppService
    {
        Task<IReadOnlyCollection<IndividualDto>> GetAllIndividualsAsync();

        Task<IndividualDto> GetIndividualByIdAsync(string id);
    }
}