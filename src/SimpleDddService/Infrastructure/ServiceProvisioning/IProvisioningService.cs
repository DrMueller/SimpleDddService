using System.Collections.Generic;

namespace SimpleDddService.Infrastructure.ServiceProvisioning
{
    public interface IProvisioningService
    {
        IReadOnlyCollection<T> GetAllServices<T>();

        T GetService<T>();
    }
}