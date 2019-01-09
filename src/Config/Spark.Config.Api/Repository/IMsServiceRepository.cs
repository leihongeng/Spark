using Spark.Config.Api.DTO;
using Spark.Config.Api.Entity;
using Spark.Core.Values;
using SmartSql.DyRepository;

namespace Spark.Config.Api.Repository
{
    public interface IMsServiceRepository : IRepository<MsService, long>
    {
        QueryByPageResponse<MsService> QueryPaged(object reqParams);

        QueryByPageResponse<MsServiceResponse> GetList(object pars);
    }
}