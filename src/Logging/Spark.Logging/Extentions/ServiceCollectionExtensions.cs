using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Spark.AspNetCore;

namespace Spark.Logging
{
    public static class ServiceCollectionExtensions
    {
        public static SparkBuilder AddLog(this SparkBuilder builder, Action<LogOptions> action)
        {
            var options = new LogOptions();
            action?.Invoke(options);

            foreach (var serviceExtension in options.Extensions)
                serviceExtension.AddServices(builder.Services);

            return builder;
        }
    }
}