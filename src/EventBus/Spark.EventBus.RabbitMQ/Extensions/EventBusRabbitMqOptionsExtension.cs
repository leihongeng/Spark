using Spark.AspNetCore;
using Spark.EventBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;

namespace Spark.EventBus.RabbitMQ
{
    public class EventBusRabbitMqOptionsExtension : IOptionsExtension
    {
        private readonly EventBusRabbitMqOptions _options;

        public EventBusRabbitMqOptionsExtension(EventBusRabbitMqOptions options)
        {
            _options = options;
        }

        public void AddServices(IServiceCollection services)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = _options.HostName,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password,
                VirtualHost = _options.VirtualHost,
                AutomaticRecoveryEnabled = true
            };

            Console.WriteLine($"{_options.HostName}_{_options.Port}_{_options.UserName}_{ _options.Password}");

            services.AddSingleton<IRabbitMQPersistentConnection>(sp => new DefaultRabbitMQPersistentConnection(
                connectionFactory,
                sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>()
            ));
            services.AddSingleton<IEventBus>(sp => new EventBusRabbitMQ(
                sp.GetRequiredService<IRabbitMQPersistentConnection>(),
                sp.GetRequiredService<ILogger<EventBusRabbitMQ>>(),
                sp,
                sp.GetRequiredService<IEventBusSubscriptionsManager>(),
                _options.QueueName,
                prefetchCount: _options.PrefetchCount,
                retryCount: 5
            ));
        }
    }
}