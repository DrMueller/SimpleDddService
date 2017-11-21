using System.Collections.Generic;
using System.Security.Claims;

namespace SimpleDddService.Infrastructure.Application.Aspects.Security.Authorization.Services
{
    public interface IClaimSearchService
    {
        IReadOnlyCollection<Claim> SearchClaimsByUserId(string userId);
    }
}