using Microsoft.Extensions.Configuration;
using System;

namespace Spark.Config
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddRemoteConfig(
            this IConfigurationBuilder builder,
            Action<IRemoteConfigurationSource> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var configSource = new RemoteConfigurationSource();
            options(configSource);

            return builder.Add(configSource);
        }
    }
}