using System.Threading.Tasks;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;
using SimpleDddService.Infrastructure.LanguageExtensions.Maybes;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices
{
    public interface IExternalCallAppService
    {
        Task<Maybe<PostAppDto>> GetOnePostAsync(bool getResult);
    }
}