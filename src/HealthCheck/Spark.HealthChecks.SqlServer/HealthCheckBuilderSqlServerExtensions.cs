using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.HealthChecks.SqlServer
{
    public static class HealthCheckBuilderSqlServerExtensions
    {
        public static HealthCheckBuilder AddSqlCheck(this HealthCheckBuilder builder, string name, string connectionString)
        {
            return AddSqlCheck(builder, name, connectionString, builder.DefaultCacheDuration);
        }

        public static HealthCheckBuilder AddSqlCheck(this HealthCheckBuilder builder, string name, string connectionString, TimeSpan cacheDuration)
        {
            return builder;
        }
    }
}