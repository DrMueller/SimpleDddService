using Microsoft.Extensions.DependencyInjection;

namespace SimpleDddService.Infrastructure.Aspects.Security.Initialization.Handlers.Implementation
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
                            c.RequireClaim("TimeReportingClaim");
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