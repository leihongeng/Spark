using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.App;
using Spark.Core.Values;
using System.Collections.Generic;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IAppServices
    {
        QueryPageResponse<AppResponse> LoadList(AppSearchRequest request);

        List<AppResponse> LoadUserAppList(long userId = 0, int isAdmin = 0);

        QueryPageResponse<AppRoleResponse> LoadRoleList(KeywordQueryPageRequest request);

        void SaveRole(AppRoleRequest request);

        void Save(AppRequest request);

        void SetStatus(BaseRequest request);
    }
}