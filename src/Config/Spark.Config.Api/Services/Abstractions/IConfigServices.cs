using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Config;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IConfigServices
    {
        QueryPageResponse<ConfigResponse> LoadList(ConfigSearchRequest request);

        Entity.Config LoadLatestConfig(ConfigLatestRequest request);

        void Save(ConfigRequest request);

        void SetStatus(BaseRequest request);
    }
}