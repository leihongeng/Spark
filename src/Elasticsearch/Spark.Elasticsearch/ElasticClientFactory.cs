using Elasticsearch.Net;
using Nest;
using System;
using System.Linq;

namespace Spark.Elasticsearch
{
    public class ElasticClientFactory : IElasticClientFactory
    {
        public ElasticClientFactory(ElasticsearchOptions options)
        {
            var urls = options.Uri.Split(';').Select(x => new Uri(x)).ToArray();
            // _logger.LogInformation($"Butterfly.Storage.Elasticsearch initialized ElasticClient with options: ElasticSearchHosts={elasticsearchHosts}.");
            var pool = new StaticConnectionPool(urls);
            var settings = new ConnectionSettings(pool).DefaultIndex(options.DefaultIndex);

            if (!String.IsNullOrEmpty(options.UserName) && !String.IsNullOrEmpty(options.Password))
            {
                settings.BasicAuthentication(options.UserName, options.Password);
            }
            Client = new ElasticClient(settings);
            DefaultIndex = options.DefaultIndex;
        }

        public ElasticClient Client { get; set; }

        public string DefaultIndex { get; set; }
    }
}