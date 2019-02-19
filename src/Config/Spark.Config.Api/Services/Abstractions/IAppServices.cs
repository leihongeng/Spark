using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.App;
using Spark.Core.Values;
using System.Collections.Generic;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IAppServices
    {
        QueryPageResponse<AppResponse> LoadList(KeywordQueryPageRequest request);

        List<AppResponse> LoadUserAppList(long userId = 0);

        void SaveRole(AppRoleRequest request);

        void Save(AppRequest request);

        void SetStatus(BaseRequest request);
    }
}