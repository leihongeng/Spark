using Spark.ServiceDiscovery.Remote;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;

namespace Ocelot.Provider.Remote
{
    public static class OcelotBuilderExtensions
    {
        public static IOcelotBuilder AddRemoteServiceDiscovery(this IOcelotBuilder builder)
        {
            builder.Services.AddSingleton(RemoteServiceDiscoveryFinderDelegate.Get);
            builder.Services.AddSingleton<IRemoteClient, RemoteClient>();
            return builder;
        }
    }
}