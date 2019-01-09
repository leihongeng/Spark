using Spark.Core.LoadBalancer;
using Spark.Core.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spark.LoadBalancer
{
    public class RoundRobin : ILoadBalancer
    {
        private readonly Func<Task<List<ServiceMeta>>> _services;
        private readonly string _serviceName;

        public RoundRobin(Func<Task<List<ServiceMeta>>> services, string serviceName)
        {
            _services = services;
            _serviceName = serviceName;
        }

        public async Task<HostAndPort> Lease()
        {
            var services = await _services.Invoke();

            if (services == null)
                throw new KeyNotFoundException($"no service for {_serviceName}");

            if (!services.Any())
                throw new KeyNotFoundException($"no service for {_serviceName}");

            int index = new Random().Next(0, services.Count);
            var service = await Task.FromResult(services[index]);
            return service.HostAndPort;
        }

        public void Release(HostAndPort hostAndPort)
        {
        }
    }
}