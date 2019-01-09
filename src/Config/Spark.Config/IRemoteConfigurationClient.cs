using Spark.Config.SDK.Entity;
using System.Threading.Tasks;

namespace Spark.Config
{
    public interface IRemoteConfigurationClient
    {
        Task<MsConfig> GetConfig(bool reloading);
    }
}