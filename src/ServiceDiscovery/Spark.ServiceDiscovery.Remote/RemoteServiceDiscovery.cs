using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spark.Core.ServiceDiscovery;
using Spark.Core.Values;

namespace Spark.ServiceDiscovery.Remote
{
    public class RemoteServiceDiscovery : IServiceDiscovery
    {
        private readonly IRemoteClient _client;

        public RemoteServiceDiscovery(IRemoteClient client)
        {
            _client = client;
        }

        public Task<List<ServiceMeta>> FindServiceInstancesAsync(string name)
        {
            return Task.Run(() =>
            {
                List<ServiceMeta> list = _client.Services
                    .Where(p => p.Name.ToLower() == name.ToLower()
                       && p.Status == 1)
                    .Select(serviceEntry =>
                        new ServiceMeta
                        {
                            Name = serviceEntry.Name,
                            HostAndPort = new HostAndPort(serviceEntry.Ip, serviceEntry.Port),
                            Version = "",
                            Tags = new string[] { },
                            Id = ""
                        }).ToList();
                return list;
            });
        }

        public Task<List<ServiceMeta>> FindAllServicesAsync()
        {
            throw new NotImplementedException();
        }
    }
}