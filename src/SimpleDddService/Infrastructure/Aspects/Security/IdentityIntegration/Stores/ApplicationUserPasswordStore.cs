using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;
using SimpleDddService.Infrastructure.Aspects.Security.IdentityIntegration.Services;

namespace SimpleDddService.Infrastructure.Aspects.Security.IdentityIntegration.Stores
{
    public class ApplicationUserPasswordStore : IUserPasswordStore<AppUser>
    {
        private readonly IAppUserCrudService _appUserCrudAppService;
        private readonly IAppUserSearchService _appUserSearchService;

        public ApplicationUserPasswordStore(IAppUserCrudService appUserCrudAppService, IAppUserSearchService appUserSearchService)
        {
            _appUserCrudAppService = appUserCrudAppService;
            _appUserSearchService = appUserSearchService;
        }

        public async Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
        {
            await _appUserCrudAppService.CreateAppUserAsync(user);
            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var maybeUser = await _appUserSearchService.SearchByIdAsync(userId);
            return maybeUser.Reduce(() => null);
        }

        public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var maybeUser = await _appUserSearchService.SearchByNormalizedUserName(normalizedUserName);
            return maybeUser.Reduce(() => null);
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.Run(
                () =>
                {
                    user.NormalizedUserName = normalizedName;
                },
                cancellationToken);
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
                            {
                                user.PasswordHash = passwordHash;
                            },
                cancellationToken);
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}