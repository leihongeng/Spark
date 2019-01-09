using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiClient;
using Spark.Config.SDK;
using Spark.Config.SDK.Entity;
using Spark.Config.SDK.DTOs;

namespace Spark.ServiceDiscovery.Remote
{
    public class RemoteClient : IRemoteClient
    {
        private readonly ILogger<RemoteClient> _logger;
        private IConfigApi _client;
        private RemoteServiceDiscoveryConfiguration _configuration;
        public List<MsService> Services { get; set; } = new List<MsService>();

        public RemoteClient(ILogger<RemoteClient> logger)
        {
            _logger = logger;
        }

        public void Inital(RemoteServiceDiscoveryConfiguration configuration)
        {
            _configuration = configuration;
            var httpApiConfig = new HttpApiConfig
            {
                HttpHost = new Uri($"http://{ _configuration.Address }:{ _configuration.Port}"),
            };
            _client = HttpApiClient.Create<IConfigApi>(httpApiConfig);
            Task.Run(() => Polling());
        }

        private void Polling()
        {
            while (true)
            {
                try
                {
                    var query = new MsServiceQuery()
                    {
                        App = _configuration.App
                    };

                    var response = _client.ServiceQuery(query).GetAwaiter().GetResult();
                    if (response.IsSuccess)
                    {
                        Services = response.Data;
                        if (_logger.IsEnabled(LogLevel.Debug))
                        {
                            _logger.LogDebug(JsonConvert.SerializeObject(Services));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "获取可用服务列表失败！");
                }
                finally
                {
                    Thread.Sleep(_configuration.PollingInterval);
                }
            }
        }
    }
}