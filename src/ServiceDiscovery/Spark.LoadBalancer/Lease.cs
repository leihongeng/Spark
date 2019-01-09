using Spark.Core.Values;

namespace Spark.LoadBalancer
{
    public class Lease
    {
        public Lease(HostAndPort hostAndPort, int connections)
        {
            HostAndPort = hostAndPort;
            Connections = connections;
        }

        public HostAndPort HostAndPort { get; private set; }
        public int Connections { get; private set; }
    }
}