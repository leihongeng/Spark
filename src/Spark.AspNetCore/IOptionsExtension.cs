using Microsoft.Extensions.DependencyInjection;

namespace Spark.AspNetCore
{
    public interface IOptionsExtension
    {
        void AddServices(IServiceCollection services);
    }
}