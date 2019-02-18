using SmartSql.DyRepository;
using Spark.Config.Api.DTO.Service;
using Spark.Config.Api.Entity;
using Spark.Core.Values;

namespace Spark.Config.Api.Repository
{
    public interface IServiceRepository : IRepository<Service, long>
    {
        QueryPageResponse<ApiServiceResponse> GetList(ApiServiceSearchRequest request);
    }
}