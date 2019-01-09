using System.Collections.Generic;
using Spark.Config.SDK.Entity;

namespace Spark.ServiceDiscovery.Remote
{
    public interface IRemoteClient
    {
        List<MsService> Services { get; set; }

        void Inital(RemoteServiceDiscoveryConfiguration configuration);
    }
}