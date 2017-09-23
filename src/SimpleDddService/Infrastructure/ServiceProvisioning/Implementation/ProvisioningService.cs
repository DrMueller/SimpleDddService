using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleDddService.Infrastructure.ServiceProvisioning.Implementation
{
    public class ProvisioningService : IProvisioningService
    {
        private readonly IServiceProvider _serviceProvider;

        public ProvisioningService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IReadOnlyCollection<T> GetAllServices<T>()
        {
            var result = _serviceProvider.GetServices<T>().ToList();
            return result;
        }

        public T GetService<T>()
        {
            var result = _serviceProvider.GetService<T>();
            return result;
        }
    }
}