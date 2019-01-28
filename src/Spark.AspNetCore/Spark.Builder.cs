using Microsoft.Extensions.DependencyInjection;

namespace Spark.AspNetCore
{
    public sealed class SparkBuilder
    {
        public SparkBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}