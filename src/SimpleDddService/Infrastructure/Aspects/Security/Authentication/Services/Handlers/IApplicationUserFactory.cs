﻿using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers
{
    public interface IApplicationUserFactory
    {
        Task<ApplicationUser> CreateUserAsync(string userIdentifier, bool setClaims);
    }
}