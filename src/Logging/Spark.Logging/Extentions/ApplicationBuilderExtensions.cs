using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
        public static ILoggerFactory AddSparkLog(this ILoggerFactory factory, IApplicationBuilder app, string projectName)
        {
            var logStore = app.ApplicationServices.GetRequiredService<ILogStore>();
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

            var provider = new SparkLogProvider(logStore, httpContextAccessor, projectName);
            factory.AddProvider(provider);
            return factory;
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="logStore"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public static ILoggerFactory AddSparkLog(this ILoggerFactory factory, ILogStore logStore, IHttpContextAccessor httpContextAccessor, string projectName)
        {
            var provider = new SparkLogProvider(logStore, httpContextAccessor, projectName);
            factory.AddProvider(provider);
            return factory;
        }
    }
}