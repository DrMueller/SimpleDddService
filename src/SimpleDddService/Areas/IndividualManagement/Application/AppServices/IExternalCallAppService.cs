using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IExternalCallAppService
    {
        Task<PostAppDto> GetFirstPostAsync();
    }
}