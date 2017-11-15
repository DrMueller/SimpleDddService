using System.Text;
using Microsoft.IdentityModel.Tokens;
using SimpleDddService.Infrastructure.Application.Settings.Services;

namespace SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices.Implementation
{
    public class SecurityKeyAppFactory : ISecurityKeyAppFactory
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public SecurityKeyAppFactory(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public SecurityKey CreateSecurityKey()
        {
            var appSettings = _appSettingsProvider.GetAppSettings();
            var utf8EncodedSecret = Encoding.UTF8.GetBytes(appSettings.SecuritySettings.SecretKey);
            var result = new SymmetricSecurityKey(utf8EncodedSecret);

            return result;
        }
    }
}