using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;
using SimpleDddService.Infrastructure.ServiceProvisioning;

namespace SimpleDddService.Infrastructure.DataAccess.Repositories.Implementatrion
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IProvisioningService _provisioningService;

        public RepositoryFactory(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public IRepository<T> CreateRepository<T>() where T : AggregateRoot
        {
            var result = _provisioningService.GetService<IRepository<T>>();
            return result;
        }
    }
}