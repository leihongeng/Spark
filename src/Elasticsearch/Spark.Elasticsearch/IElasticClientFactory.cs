using Nest;

namespace Spark.Elasticsearch
{
    public interface IElasticClientFactory
    {
        ElasticClient Client { get; set; }
        string DefaultIndex { get; set; }
    }
}