﻿using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task<ApplicationUser> AuthenticateAsync(AuthenticationRequest authenticationRequest);
    }
}