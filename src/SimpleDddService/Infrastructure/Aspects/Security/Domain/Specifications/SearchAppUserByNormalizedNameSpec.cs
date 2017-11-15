using System;
using System.Linq.Expressions;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;
using SimpleDddService.Infrastructure.DomainExtensions.Specifications.Implementation;

namespace SimpleDddService.Infrastructure.Aspects.Security.Domain.Specifications
{
    public class SearchAppUserByNormalizedNameSpec : SpecificationBase<AppUser>
    {
        private readonly string _normalizedUserNameToSearch;

        public SearchAppUserByNormalizedNameSpec(string normalizedUserNameToSearch)
        {
            _normalizedUserNameToSearch = normalizedUserNameToSearch;
        }

        public override Expression<Func<AppUser, bool>> ToExpression()
        {
            return appUser => appUser.NormalizedUserName == _normalizedUserNameToSearch;
        }
    }
}