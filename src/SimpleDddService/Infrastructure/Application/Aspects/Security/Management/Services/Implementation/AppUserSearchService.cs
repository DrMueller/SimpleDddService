﻿using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services.Specifications;
using SimpleDddService.Infrastructure.DataAccess.Repositories;
using SimpleDddService.Infrastructure.LanguageExtensions.Maybes;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Services.Implementation
{
    public class AppUserSearchService : IAppUserSearchService
    {
        private readonly IRepository<AppUser> _appUserRepository;

        public AppUserSearchService(IRepository<AppUser> appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<Maybe<AppUser>> SearchByIdAsync(string userId)
        {
            var foundAppUser = await _appUserRepository.LoadByIdAsync(userId);
            return MaybeFactory.CreateFromNullable(foundAppUser);
        }

        public async Task<Maybe<AppUser>> SearchByNormalizedUserName(string normalizedUserName)
        {
            var searchAppUserByNameSpec = new SearchAppUserByNormalizedNameSpec(normalizedUserName);
            var foundAppUser = await _appUserRepository.LoadSingleAsync(searchAppUserByNameSpec);

            return MaybeFactory.CreateFromNullable(foundAppUser);
        }
    }
}