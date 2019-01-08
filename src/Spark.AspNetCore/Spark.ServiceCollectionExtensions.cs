using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static SparkBuilder AddSpark(this IServiceCollection services, Action<SparkOptions> setupAction)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddHttpClient();

            services.AddSingleton<IStartupFilter, StartupFilter>();
            services.AddHostedService<DiagnosticHostedService>();

            var options = new SparkOptions();
            setupAction(options);
            foreach (var serviceExtension in options.Extensions)
            {
                serviceExtension.AddServices(services);
            }
            services.AddSingleton(options);

            return new SparkBuilder(services);
        }
    }
}