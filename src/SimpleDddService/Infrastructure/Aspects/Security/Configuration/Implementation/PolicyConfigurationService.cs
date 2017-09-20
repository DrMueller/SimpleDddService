using Microsoft.AspNetCore.Authorization;

namespace SimpleDddService.Infrastructure.Aspects.Security.Configuration.Implementation
{
    public class PolicyConfigurationService : IPolicyConfigurationService
    {
        public void ConfigurePolicies(AuthorizationOptions authorizationOptions)
        {
            authorizationOptions.AddPolicy(
                "TimeReporting",
                c =>
                {
                    c.RequireClaim("TimeReportingClaim");
                });

            authorizationOptions.AddPolicy(
                "GetAllWrongBookedEntries",
                c =>
                {
                    c.RequireUserName("SCL");
                });

            authorizationOptions.AddPolicy(
                "EditGeneralEvent",
                c =>
                {
                    c.RequireClaim("EditGeneralEventClaim");
                });

            authorizationOptions.AddPolicy(
                "TestNotFullfilled",
                c =>
                {
                    c.RequireUserName("TRA");
                });
        }
    }
}