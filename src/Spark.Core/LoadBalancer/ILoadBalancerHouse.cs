using System.Threading.Tasks;

namespace Spark.Core.LoadBalancer
{
    public interface ILoadBalancerHouse
    {
        Task<ILoadBalancer> Get(string serviceName, string balancer = "RoundRobin");
    }
}