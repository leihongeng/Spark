using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.HealthChecks
{
    public enum CheckStatus
    {
        Unknown,
        Unhealthy,
        Healthy,
        Warning
    }
}