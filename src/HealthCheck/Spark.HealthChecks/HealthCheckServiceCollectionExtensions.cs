using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.HealthChecks
{
    public static class HealthCheckServiceCollectionExtensions
    {
        private static readonly Type HealthCheckServiceInterface = typeof(IHealthCheckService);

        public static SparkBuilder AddHealthChecks(this SparkBuilder services, Action<HealthCheckBuilder> checks)
        {
            return services;
        }
    }
}