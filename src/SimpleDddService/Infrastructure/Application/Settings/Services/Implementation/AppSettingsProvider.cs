using Microsoft.Extensions.Options;
using SimpleDddService.Infrastructure.Application.Settings.Models;

namespace SimpleDddService.Infrastructure.Application.Settings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _appSettingsOptions;

        public AppSettingsProvider(IOptions<AppSettings> appSettingsOptions)
        {
            _appSettingsOptions = appSettingsOptions;
        }

        public AppSettings GetAppSettings()
        {
            return _appSettingsOptions.Value;
        }
    }
}