using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore;
using System;

namespace Spark.Elasticsearch
{
    public static class ServiceCollectionExtensions
    {
        public static SparkBuilder AddElasticesearch(this SparkBuilder builder, IConfiguration configuration)
        {
            var elasticsearchOptions = new ElasticsearchOptions();
            configuration.GetSection("GlobalConfig:ElasticsearchOptions").Bind(elasticsearchOptions);
            builder.Services.AddSingleton(elasticsearchOptions);
            builder.Services.AddSingleton<IElasticClientFactory, ElasticClientFactory>();
            builder.Services.AddSingleton<IIndexManager, IndexManager>();

            return builder;
        }

        public static SparkBuilder AddElasticesearch(this SparkBuilder builder, Action<ElasticsearchOptions> actions)
        {
            if (actions == null)
                throw new ArgumentNullException("actions");

            var elasticsearchOptions = new ElasticsearchOptions();
            actions.Invoke(elasticsearchOptions);

            builder.Services.AddSingleton(elasticsearchOptions);
            builder.Services.AddSingleton<IElasticClientFactory, ElasticClientFactory>();
            builder.Services.AddSingleton<IIndexManager, IndexManager>();

            return builder;
        }
    }
}