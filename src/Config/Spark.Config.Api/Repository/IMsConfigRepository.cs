using Spark.Config.Api.DTOs;
using Spark.Config.Api.Entity;
using Spark.Core.Values;
using SmartSql.DyRepository;

namespace Spark.Config.Api.Repository
{
    public interface IMsConfigRepository : IRepository<MsConfig, int>
    {
        QueryByPageResponse<MsConfig> QueryPaged(object reqParams);

        QueryByPageResponse<MsConfigResponse> GetList(object reqParams);
    }
}