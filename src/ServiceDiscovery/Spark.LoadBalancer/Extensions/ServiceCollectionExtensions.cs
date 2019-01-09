using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore;
using Spark.Core.LoadBalancer;

namespace Spark.LoadBalancer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加负载均衡器
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static SparkBuilder AddLoadBalancer(this SparkBuilder builder)
        {
            builder.Services.AddSingleton<ILoadBalancerFactory, LoadBalancerFactory>();
            builder.Services.AddSingleton<ILoadBalancerHouse, LoadBalancerHouse>();

            return builder;
        }
    }
}