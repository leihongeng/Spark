using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Spark.AspNetCore;

namespace Spark.Logging.EventBusStore.Extentions
{
    public class LogEventBusOptionsExtension : IOptionsExtension
    {
        private IConfiguration configuration;

        public LogEventBusOptionsExtension(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void AddServices(IServiceCollection services)
        {
            services.AddSingleton<ILogStore, LogStore>();
        }
    }
}