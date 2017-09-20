using SimpleDddService.Infrastructure.Application.Settings.Models;

namespace SimpleDddService.Infrastructure.Application.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings GetAppSettings();
    }
}
