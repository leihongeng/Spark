using Microsoft.Extensions.DependencyInjection;
using Ocelot.ServiceDiscovery.Providers;
using Ocelot.Values;
using Spark.ServiceDiscovery.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocelot.Provider.Remote
{
    public class RemoteServiceDiscoveryProvider : IServiceDiscoveryProvider
    {
        private readonly IRemoteClient client;
        private string name;

        public RemoteServiceDiscoveryProvider(IServiceProvider provider, string name)
        {
            client = provider.GetService<IRemoteClient>();
            this.name = name;
        }

        public async Task<List<Service>> Get()
        {
            //从配置中心获取服务列表
            var list = client.Services
                .Where(x => x.Name.ToLower() == name.ToLower() && x.Status == 1)
                .Select(x => new Service(x.Name, new ServiceHostAndPort(x.Ip, x.Port), x.Name, "", null))
                .ToList();

            return await Task.FromResult(list);
        }
    }
}