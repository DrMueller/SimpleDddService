using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.Dtos;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IExternalCallAppService
    {
        Task<PostDto> GetFirstPostAsync();
    }
}