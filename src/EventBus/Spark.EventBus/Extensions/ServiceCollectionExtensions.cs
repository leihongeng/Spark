using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore;
using System;

namespace Spark.EventBus.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 事件驱动
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static SparkBuilder AddEventBus(this SparkBuilder builder, Action<EventBusOptions> configAction)
        {
            if (configAction == null) throw new ArgumentNullException(nameof(configAction));

            var options = new EventBusOptions();
            configAction?.Invoke(options);

            builder.Services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            foreach (var serviceExtension in options.Extensions)
                serviceExtension.AddServices(builder.Services);

            return builder;
        }
    }
}