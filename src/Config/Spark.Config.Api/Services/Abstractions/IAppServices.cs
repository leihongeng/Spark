using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.App;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IAppServices
    {
        QueryPageResponse<AppResponse> LoadList(KeywordQueryPageRequest request);

        void SaveRole(AppRoleRequest request);

        void Save(AppRequest request);

        void Remove(BaseRequest request);
    }
}