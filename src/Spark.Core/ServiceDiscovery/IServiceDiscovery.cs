using Spark.Core.Values;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Core.ServiceDiscovery
{
    public interface IServiceDiscovery
    {
        Task<List<ServiceMeta>> FindServiceInstancesAsync(string name);

        Task<List<ServiceMeta>> FindAllServicesAsync();
    }
}