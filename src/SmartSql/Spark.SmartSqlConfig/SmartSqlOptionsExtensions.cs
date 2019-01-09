using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmartSql;
using SmartSql.Abstractions.Config;
using SmartSql.Logging;
using System;

namespace Spark.SmartSqlConfig
{
    public static class SmartSqlOptionsExtensions
    {
        private static IConfigLoader BuildConfigLoader(IServiceProvider sp, string configName)
        {
            var loggerFactory = sp.GetService<ILoggerFactory>() ?? NoneLoggerFactory.Instance;
            var optionsMonitor = sp.GetService<IOptionsMonitor<SmartSqlDbConfigOptions>>();

            var smartSqlOptions = String.IsNullOrEmpty(configName)
                                        ? optionsMonitor.CurrentValue : optionsMonitor.Get(configName);

            var _configLoader = new OptionConfigLoader(smartSqlOptions, loggerFactory);
            optionsMonitor.OnChange((ops, name) =>
            {
                _configLoader.TriggerChanged(ops);
            });

            return _configLoader;
        }

        public static SmartSqlOptions UseOptions(this SmartSqlOptions smartSqlOptions, IServiceProvider sp)
        {
            var configLoader = BuildConfigLoader(sp, smartSqlOptions.ConfigPath);
            smartSqlOptions.ConfigLoader = configLoader;
            return smartSqlOptions;
        }
    }
}