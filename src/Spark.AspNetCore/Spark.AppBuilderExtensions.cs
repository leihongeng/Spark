using Microsoft.AspNetCore.Builder;
using Spark.AspNetCore.Middleware;
using Spark.AspNetCore.Middleware.Statistics;

namespace Spark.AspNetCore
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseGlobalErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalErrorMiddleware>();
        }

        public static IApplicationBuilder UseHttpMethodMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpMethodMiddleware>();
        }

        public static IApplicationBuilder UseStatisticsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StatisticsMiddleware>();
        }
    }
}