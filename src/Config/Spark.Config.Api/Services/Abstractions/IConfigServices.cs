using Spark.Config.Api.DTO.Config;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IConfigServices
    {
        QueryPageResponse<ConfigResponse> LoadList(KeywordQueryPageRequest request);
    }
}