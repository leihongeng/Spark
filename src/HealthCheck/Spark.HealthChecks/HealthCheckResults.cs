using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.HealthChecks
{
    public class HealthCheckResults
    {
        public IList<IHealthCheckResult> CheckResults { get; } = new List<IHealthCheckResult>();
    }
}