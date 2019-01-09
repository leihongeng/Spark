using Spark.Core.LoadBalancer;
using Spark.Core.Values;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spark.LoadBalancer
{
    public class NoLoadBalancer : ILoadBalancer
    {
        private readonly List<ServiceMeta> _services;

        public NoLoadBalancer(List<ServiceMeta> services)
        {
            _services = services;
        }

        public async Task<HostAndPort> Lease()
        {
            var service = await Task.FromResult(_services.FirstOrDefault());
            return service.HostAndPort;
        }

        public void Release(HostAndPort hostAndPort)
        {
        }
    }
}