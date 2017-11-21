using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Factories;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Models;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Common.Stores;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Initialization.Services.Handlers;
using SimpleDddService.Infrastructure.Application.Aspects.Security.Management.Models;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Initialization.Services.Implementation
{
    public class SecurityInitializationService : ISecurityInitializationService
    {
        private readonly IPolicyConfigurationHandler _policyConfigurationHandler;
        private readonly ISecurityKeyFactory _securityKeyFactory;

        public SecurityInitializationService(IPolicyConfigurationHandler policyConfigurationHandler, ISecurityKeyFactory securityKeyFactory)
        {
            _policyConfigurationHandler = policyConfigurationHandler;
            _securityKeyFactory = securityKeyFactory;
        }

        public void InitializeSecurity(IServiceCollection services)
        {
            InitializeJwtAuthentication(services);
            InitializeSecurityServices(services);

            _policyConfigurationHandler.InitializePolicyAuthorization(services);
        }

        private void InitializeJwtAuthentication(IServiceCollection services)
        {
            var securityKey = _securityKeyFactory.CreateSecurityKey();

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

            services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(
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
            services.AddScoped<IUserStore<AppUser>, AppUserStore>();
            services.AddScoped<IRoleStore<Role>, RoleStore>();
            services.AddSingleton<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
        }
    }
}