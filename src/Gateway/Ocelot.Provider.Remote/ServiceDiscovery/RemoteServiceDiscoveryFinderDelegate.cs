using Ocelot.ServiceDiscovery;

namespace Ocelot.Provider.Remote
{
    public static class RemoteServiceDiscoveryFinderDelegate
    {
        public static ServiceDiscoveryFinderDelegate Get = (provider, config, name) =>
        {
            return new RemoteServiceDiscoveryProvider(provider, name);
        };
    }
}