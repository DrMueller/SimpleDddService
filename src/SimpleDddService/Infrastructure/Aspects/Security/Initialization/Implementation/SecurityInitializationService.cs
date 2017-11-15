using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimpleDddService.Infrastructure.Aspects.Security.Application.AppServices;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;
using SimpleDddService.Infrastructure.Aspects.Security.IdentityIntegration.Models;
using SimpleDddService.Infrastructure.Aspects.Security.IdentityIntegration.Stores;
using SimpleDddService.Infrastructure.Aspects.Security.Initialization.Handlers;

namespace SimpleDddService.Infrastructure.Aspects.Security.Initialization.Implementation
{
    public class SecurityInitializationService : ISecurityInitializationService
    {
        private readonly IPolicyConfigurationHandler _policyConfigurationHandler;
        private readonly ISecurityKeyAppFactory _securityKeyAppFactory;

        public SecurityInitializationService(IPolicyConfigurationHandler policyConfigurationHandler, ISecurityKeyAppFactory securityKeyAppFactory)
        {
            _policyConfigurationHandler = policyConfigurationHandler;
            _securityKeyAppFactory = securityKeyAppFactory;
        }

        public void InitializeSecurity(IServiceCollection services)
        {
            InitializeJwtAuthentication(services);
            InitializeSecurityServices(services);

            _policyConfigurationHandler.InitializePolicyAuthorization(services);
        }

        private void InitializeJwtAuthentication(IServiceCollection services)
        {
            var securityKey = _securityKeyAppFactory.CreateSecurityKey();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = false,
                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = securityKey
            };

            services.AddAuthentication().AddJwtBearer(
                options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameters;
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                                                 {
                                                     if (Debugger.IsAttached)
                                                     {
                                                         Debugger.Break();
                                                     }

                                                     Console.WriteLine(
                                                         "OnAuthenticationFailed: " +
                                                         context.Exception.Message);
                                                     return Task.CompletedTask;
                                                 },
                        OnTokenValidated = context =>
                                           {
                                               Console.WriteLine(
                                                   "OnTokenValidated: " +
                                                   context.SecurityToken);
                                               return Task.CompletedTask;
                                           }
                    };
                });
        }

        private static void InitializeSecurityServices(IServiceCollection services)
        {
            services.AddIdentity<AppUser, Role>();
            services.AddScoped<IUserStore<AppUser>, ApplicationUserPasswordStore>();
            services.AddScoped<IRoleStore<Role>, RoleStore>();
            services.AddSingleton<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
        }
    }
}