namespace Ocelot.Provider.Consul
{
    using Configuration.Repository;
    using DependencyInjection;
    using global::Consul;
    using Microsoft.Extensions.DependencyInjection;
    using Middleware;
    using ServiceDiscovery;
    using System;

    public static class OcelotBuilderExtensions
    {
        public static IOcelotBuilder AddConsul(this IOcelotBuilder builder)
        {
            builder.Services.AddSingleton<ServiceDiscoveryFinderDelegate>(ConsulProviderFactory.Get);
            builder.Services.AddSingleton<IConsulClient>(x =>
            {
                var rep = x.GetRequiredService<IInternalConfigurationRepository>();
                return new ConsulClient(c =>
                {
                    var ServiceProviderConfiguration = rep.Get().Data.ServiceProviderConfiguration;
                    c.Address = new Uri($"http://{ServiceProviderConfiguration.Host}:{ServiceProviderConfiguration.Port}");
                });
            });
            return builder;
        }

        public static IOcelotBuilder AddConfigStoredInConsul(this IOcelotBuilder builder)
        {
            builder.Services.AddSingleton<OcelotMiddlewareConfigurationDelegate>(ConsulMiddlewareConfigurationProvider.Get);
            builder.Services.AddHostedService<FileConfigurationPoller>();
            builder.Services.AddSingleton<IFileConfigurationRepository, ConsulFileConfigurationRepository>();
            return builder;
        }
    }
}