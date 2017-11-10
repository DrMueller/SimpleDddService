using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using SimpleDddService.Infrastructure.Application.Middlewares;

namespace SimpleDddService.Infrastructure.Application.Initialization
{
    internal static class AppInitialization
    {
        internal static void InitializeApplication(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            InitializeMiddlewares(app);
            InitializeCors(app);
            InitializeNlog(env, loggerFactory);
            InitializeSecurity(app);
            app.UseAuthentication();
            app.UseMvc();
        }

        private static void InitializeCors(IApplicationBuilder app)
        {
            app.UseCors("All");
        }

        private static void InitializeMiddlewares(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        private static void InitializeNlog(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");
        }

        private static void InitializeSecurity(IApplicationBuilder app)
        {
            app.UseIdentityServer();
        }
    }
}