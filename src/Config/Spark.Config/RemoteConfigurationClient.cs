using Spark.Config.SDK;
using Spark.Config.SDK.Entity;
using System;
using System.Threading.Tasks;
using Spark.Config.SDK.DTOs;
using WebApiClient;

namespace Spark.Config
{
    public class RemoteConfigurationClient : IRemoteConfigurationClient
    {
        private readonly IRemoteConfigurationSource _remoteConfigSource;
        private readonly IConfigApi _apiClient;

        private DateTime _updateTime = DateTime.Now;

        public RemoteConfigurationClient(IRemoteConfigurationSource remoteConfigSource)
        {
            _remoteConfigSource = remoteConfigSource;
            _apiClient = HttpApiClient.Create<IConfigApi>(
                new HttpApiConfig
                {
                    HttpHost = new Uri(_remoteConfigSource.Url)
                });
        }

        public async Task<MsConfig> GetConfig(bool reloading)
        {
            var query = new MsConfigQuery()
            {
                App = _remoteConfigSource.App,
                Key = _remoteConfigSource.Key,
            };
            if (reloading)
            {
                query.UpdateTime = _updateTime;
            }
            var result = await _apiClient.ConfigQuery(query);

            if (result?.Data != null && result?.IsSuccess == true)
            {
                _updateTime = result.Data.UpdateTime;
            }

            return await Task.FromResult(result?.Data);
        }
    }
}