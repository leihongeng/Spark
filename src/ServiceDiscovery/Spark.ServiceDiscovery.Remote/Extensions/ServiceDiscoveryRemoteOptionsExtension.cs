using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Spark.AspNetCore;
using Spark.Core.ServiceDiscovery;

namespace Spark.ServiceDiscovery.Remote.Extensions
{
    public class ServiceDiscoveryRemoteOptionsExtension : IOptionsExtension
    {
        private readonly RemoteServiceDiscoveryConfiguration _options;

        public ServiceDiscoveryRemoteOptionsExtension(RemoteServiceDiscoveryConfiguration options)
        {
            _options = options;
        }

        public void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IRemoteClient, RemoteClient>();
            services.AddSingleton(_options);

            services.AddSingleton<IServiceDiscovery>(f =>
            {
                var client = f.GetRequiredService<IRemoteClient>();

                //初始化
                client.Inital(_options);

                return new RemoteServiceDiscovery(client);
            });
        }
    }
}