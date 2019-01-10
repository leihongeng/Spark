using Spark.EventBus.Extensions;
using Microsoft.Extensions.Configuration;
using System;

namespace Spark.EventBus.RabbitMQ
{
    public static class EventBusOptionsExtension
    {
        /// <summary>
        /// 使用RabbitMq做事件总线
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static EventBusOptions UseRabbitMQ(this EventBusOptions options, Action<EventBusRabbitMqOptions> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));
            var setting = new EventBusRabbitMqOptions();
            configure.Invoke(setting);
            options.RegisterExtension(new EventBusRabbitMqOptionsExtension(setting));
            return options;
        }

        /// <summary>
        /// 使用RabbitMq做事件总线
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        /// <param name="queenName"></param>
        /// <returns></returns>
        public static EventBusOptions UseRabbitMQ(this EventBusOptions options, IConfiguration configuration, string queenName = "")
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var setting = new EventBusRabbitMqOptions();
            configuration.GetSection("GlobalConfig:EventBus:RabbitMQ").Bind(setting);
            setting.QueueName = queenName;
            options.RegisterExtension(new EventBusRabbitMqOptionsExtension(setting));

            return options;
        }
    }
}