using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleDddService.Infrastructure.Aspects.Security.Authentication.Models;

namespace SimpleDddService.Infrastructure.Aspects.Security.Authentication.Services.Handlers
{
    public interface IClaimProvider
    {
        Task<IReadOnlyCollection<ApplicationClaim>> GetClaimsAsync(string userIdentifier);
    }
}