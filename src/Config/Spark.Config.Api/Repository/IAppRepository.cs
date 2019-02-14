using SmartSql.DyRepository;
using Spark.Config.Api.DTO.App;
using Spark.Config.Api.Entity;
using Spark.Core.Values;

namespace Spark.Config.Api.Repository
{
    public interface IAppRepository : IRepository<App, long>
    {
        QueryPageResponse<AppResponse> GetList(KeywordQueryPageRequest request);
    }
}