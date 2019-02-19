using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Service;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IApiServices
    {
        QueryPageResponse<ApiServiceResponse> LoadList(ApiServiceSearchRequest request);

        void Save(ApiServiceRequest request);

        void SetStatus(BaseRequest request);
    }
}