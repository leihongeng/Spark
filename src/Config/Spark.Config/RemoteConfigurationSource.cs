using Microsoft.Extensions.Configuration;
using System;

namespace Spark.Config
{
    public class RemoteConfigurationSource : IRemoteConfigurationSource
    {
        public string App { get; set; }

        public string Key { get; set; }

        public bool Optional { get; set; } = false;

        public bool ReloadOnChange { get; set; } = false;

        public string Url { get; set; }

        public int Interval { get; set; } = 30000;

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            if (string.IsNullOrWhiteSpace(Url))
            {
                throw new Exception("ConfigUrl不能为空！");
            }
            var client = new RemoteConfigurationClient(this);
            return new RemoteConfigurationProvider(this, client);
        }
    }
}