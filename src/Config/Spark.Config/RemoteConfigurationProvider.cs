using Spark.Config.Extensions;
using Spark.Config.SDK.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Spark.Config
{
    public class RemoteConfigurationProvider : ConfigurationProvider
    {
        private readonly IRemoteConfigurationClient _remoteClient;
        private readonly IRemoteConfigurationSource _source;

        public RemoteConfigurationProvider(IRemoteConfigurationSource source
            , IRemoteConfigurationClient remoteClient)
        {
            _remoteClient = remoteClient;
            _source = source;
            if (_source.ReloadOnChange)
            {
                Task.Run(() => PollForChanges());
            }
        }

        public override void Load()
        {
            try
            {
                var config = _remoteClient.GetConfig(false).Result;

                Console.WriteLine(JsonConvert.SerializeObject(config));

                OnChange(config);
            }
            catch (Exception ex)
            {
                throw new Exception("初始获取项目配置异常！", ex);
            }
        }

        private async void PollForChanges()
        {
            while (true)
            {
                await Task.Delay(_source.Interval);
                try
                {
                    var config = await _remoteClient.GetConfig(true);
                    OnChange(config);
                }
                catch (Exception ex)
                {
                    Console.Write($"获取配置信息失败:{ex.Message}");
                }
            }
        }

        private void OnChange(MsConfig config)
        {
            if (config != null)
            {
                Data = config.ConvertToConfig(_source.Key)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value, StringComparer.OrdinalIgnoreCase);
                OnReload();
            }
        }
    }
}