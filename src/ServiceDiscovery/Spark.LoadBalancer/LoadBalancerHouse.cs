using Spark.Core.LoadBalancer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spark.LoadBalancer
{
    public class LoadBalancerHouse : ILoadBalancerHouse
    {
        private readonly ILoadBalancerFactory _factory;
        private readonly ConcurrentDictionary<string, ILoadBalancer> _loadBalancers;

        public LoadBalancerHouse(ILoadBalancerFactory factory)
        {
            _factory = factory;
            _loadBalancers = new ConcurrentDictionary<string, ILoadBalancer>();
        }

        public async Task<ILoadBalancer> Get(string serviceName, string balancer)
        {
            try
            {
                if (_loadBalancers.TryGetValue(serviceName, out var balancerInstance))
                {
                    if (balancer != balancerInstance.GetType().Name)
                    {
                        balancerInstance = await _factory.Get(serviceName, balancer);
                        AddLoadBalancer(serviceName, balancerInstance);
                    }
                    return balancerInstance;
                }

                balancerInstance = await _factory.Get(serviceName, balancer);
                AddLoadBalancer(serviceName, balancerInstance);
                return balancerInstance;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException($"unabe to find load balancer for {serviceName} exception is {ex}");
            }
        }

        private void AddLoadBalancer(string key, ILoadBalancer loadBalancer)
        {
            _loadBalancers.AddOrUpdate(key, loadBalancer, (x, y) => loadBalancer);
        }
    }
}