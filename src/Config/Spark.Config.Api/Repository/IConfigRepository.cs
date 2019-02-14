using SmartSql.DyRepository;
using Spark.Config.Api.DTO.Config;
using Spark.Core.Values;

namespace Spark.Config.Api.Repository
{
    public interface IConfigRepository : IRepository<Entity.Config, long>
    {
        QueryPageResponse<ConfigResponse> GetList(KeywordQueryPageRequest request);
    }
}