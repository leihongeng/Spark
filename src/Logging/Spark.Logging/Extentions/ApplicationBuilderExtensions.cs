using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Spark.Logging
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="app"></param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSparkLog(this IApplicationBuilder app)
        {
            var factory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
            var logStore = app.ApplicationServices.GetRequiredService<ILogStore>();
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

            var config = app.ApplicationServices.GetRequiredService<IConfiguration>();

            var provider = new SparkLogProvider(logStore, httpContextAccessor, Environment.GetEnvironmentVariable("AppName"), config["ServiceName"]);
            factory.AddProvider(provider);

            return app;
        }
    }
}