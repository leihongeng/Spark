using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.HealthChecks
{
    public class HealthCheckBuilder
    {
        public TimeSpan DefaultCacheDuration { get; set; }

        public HealthCheckBuilder AddCheck<TCheck>(string checkName, TimeSpan cacheDuration) where TCheck : class, IHealthCheck
        {
            return this;
        }

        public HealthCheckBuilder AddCheck(string checkName, IHealthCheck check, TimeSpan cacheDuration)
        {
            return this;
        }
    }
}