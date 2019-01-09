using System.Net;

namespace Spark.ServiceDiscovery.Remote
{
    public class RemoteServiceDiscoveryConfiguration
    {
        public string Address { get; set; }

        public int Port { get; set; }

        public string App { get; set; }

        public int PollingInterval { get; set; } = 30000;

        public IPEndPoint ToIPEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(Address), Port);
        }
    }
}