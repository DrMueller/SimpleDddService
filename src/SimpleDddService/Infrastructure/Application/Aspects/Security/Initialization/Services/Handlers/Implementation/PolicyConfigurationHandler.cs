using Microsoft.Extensions.DependencyInjection;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Initialization.Services.Handlers.Implementation
{
    public class PolicyConfigurationHandler : IPolicyConfigurationHandler
    {
        public void InitializePolicyAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy(
                        "TimeReporting",
                        c =>
                        {
                            c.RequireClaim("TimeReportingClaim", "Tra");
                        });

                    options.AddPolicy(
                        "GetAllWrongBookedEntries",
                        c =>
                        {
                            c.RequireUserName("SCL");
                        });

                    options.AddPolicy(
                        "EditGeneralEvent",
                        c =>
                        {
                            c.RequireClaim("EditGeneralEventClaim");
                        });

                    options.AddPolicy(
                        "TestNotFullfilled",
                        c =>
                        {
                            c.RequireUserName("TRA");
                        });
                });
        }
    }
}