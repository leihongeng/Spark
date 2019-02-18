using System.Collections.Generic;
using SmartSql.DyRepository;
using Spark.Config.Api.DTO.App;
using Spark.Config.Api.Entity;
using Spark.Core.Values;

namespace Spark.Config.Api.Repository
{
    public interface IAppRepository : IRepository<App, long>
    {
        QueryPageResponse<AppResponse> GetList(KeywordQueryPageRequest request);

        List<AppResponse> GetUserAppList([Param(name: "UserId")]long userId);

        long InsertRole(AppRole role);

        void DeleteRole(object obj);

        List<AppRole> QueryRoleList(object obj);
    }
}