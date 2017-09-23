using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Implementation;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Stores;
using SimpleDddService.Infrastructure.Aspects.Security.Configuration;
using StructureMap;

namespace SimpleDddService.Infrastructure.Application.Initialization.Handlers
{
    internal static class SecurityInitialization
    {
        internal static void InitializeSecurity(IServiceCollection services, IContainer container)
        {
            services.AddAuthentication().AddCookie();

            services.AddIdentity<ApplicationUser, Role>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppUserClaimsPrincipalFactory>();
            services.AddScoped<IUserStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IRoleStore<Role>, RoleStore>();

            ConfigurePolicies(services, container);
            ConfigureApplicationCookie(services);
            ConfigureIdentityOptions(services);
        }

        private static void ConfigureApplicationCookie(IServiceCollection services)
        {
            services.ConfigureApplicationCookie(
                options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Expiration = TimeSpan.FromDays(150);
                    options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                    options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                    options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                    options.SlidingExpiration = true;
                });
        }

        private static void ConfigureIdentityOptions(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(
                options =>
                {
                    // Password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 6;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings
                    options.User.RequireUniqueEmail = true;
                });
        }

        private static void ConfigurePolicies(IServiceCollection services, IContainer container)
        {
            var policyConfigurationService = container.GetInstance<IPolicyConfigurationService>();
            services.AddAuthorization(o => policyConfigurationService.ConfigurePolicies(o));
        }
    }
}