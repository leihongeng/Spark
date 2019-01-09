using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.Logging.EventBusStore.Extentions
{
    public static class LogOptionsExtension
    {
        public static LogOptions UseEventBusLog(this LogOptions options, IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            options.RegisterExtension(new LogEventBusOptionsExtension(configuration));

            return options;
        }
    }
}