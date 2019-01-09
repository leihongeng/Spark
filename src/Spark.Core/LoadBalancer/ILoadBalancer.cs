using Spark.Core.Values;
using System.Threading.Tasks;

namespace Spark.Core.LoadBalancer
{
    public interface ILoadBalancer
    {
        Task<HostAndPort> Lease();

        void Release(HostAndPort hostAndPort);
    }
}