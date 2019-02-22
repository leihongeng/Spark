using System.Collections.Generic;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Service;
using Spark.Config.Api.Entity;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IApiServices
    {
        QueryPageResponse<ApiServiceResponse> LoadList(ApiServiceSearchRequest request);

        List<Service> LoadList(string appCode);

        void Save(ApiServiceRequest request);

        void SetStatus(BaseRequest request);
    }
}