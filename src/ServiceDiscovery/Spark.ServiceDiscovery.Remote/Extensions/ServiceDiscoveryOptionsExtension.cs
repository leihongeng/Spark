using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Spark.ServiceDiscovery.Remote.Extensions
{
    public static class ServiceDiscoveryOptionsExtension
    {
        public static ServiceDiscoveryOptions UseRemote(this ServiceDiscoveryOptions options, Action<RemoteServiceDiscoveryConfiguration> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var setting = new RemoteServiceDiscoveryConfiguration();
            configure?.Invoke(setting);

            options.RegisterExtension(new ServiceDiscoveryRemoteOptionsExtension(setting));

            return options;
        }

        public static ServiceDiscoveryOptions UseRemote(this ServiceDiscoveryOptions options, IConfiguration configuration, string key = "GlobalConfig")
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var setting = new RemoteServiceDiscoveryConfiguration();

            configuration.GetSection(key).GetSection("ServiceDiscoveryOptions").Bind(setting);

            options.RegisterExtension(new ServiceDiscoveryRemoteOptionsExtension(setting));

            return options;
        }
    }
}