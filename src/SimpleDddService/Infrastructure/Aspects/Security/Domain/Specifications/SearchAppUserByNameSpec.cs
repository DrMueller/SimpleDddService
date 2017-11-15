using System;
using System.Linq.Expressions;
using SimpleDddService.Infrastructure.Aspects.Security.Domain.Models;
using SimpleDddService.Infrastructure.DomainExtensions.Specifications.Implementation;

namespace SimpleDddService.Infrastructure.Aspects.Security.Domain.Specifications
{
    public class SearchAppUserByNameSpec : SpecificationBase<AppUser>
    {
        private readonly string _userNameToSearch;

        public SearchAppUserByNameSpec(string userNameToSearch)
        {
            _userNameToSearch = userNameToSearch;
        }

        public override Expression<Func<AppUser, bool>> ToExpression()
        {
            return appUser => appUser.UserName == _userNameToSearch;
        }
    }
}