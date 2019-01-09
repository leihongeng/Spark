using Microsoft.Extensions.Configuration;

namespace Spark.Config
{
    public interface IRemoteConfigurationSource : IConfigurationSource
    {
        string App { get; set; }

        /// <summary>
        /// 查询key
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// 配置服务地址
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// 循环获取时间间隔
        /// </summary>
        int Interval { get; set; }

        bool Optional { get; set; }

        bool ReloadOnChange { get; set; }
    }
}