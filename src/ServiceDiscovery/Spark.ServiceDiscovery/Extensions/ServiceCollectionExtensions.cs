using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore;
using System;

namespace Spark.ServiceDiscovery.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 服务发现
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static SparkBuilder AddServiceDiscovery(this SparkBuilder builder, Action<ServiceDiscoveryOptions> configAction)
        {
            if (configAction == null) throw new ArgumentNullException(nameof(configAction));

            var options = new ServiceDiscoveryOptions();
            configAction?.Invoke(options);

            foreach (var serviceExtension in options.Extensions)
                serviceExtension.AddServices(builder.Services);

            return builder;
        }
    }
}