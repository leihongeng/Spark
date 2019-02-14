using SmartSql.DyRepository;
using Spark.Config.Api.DTO.User;
using Spark.Config.Api.Entity;
using Spark.Core.Values;

namespace Spark.Config.Api.Repository
{
    public interface IUserRepository : IRepository<User, long>
    {
        QueryPageResponse<UserResponse> GetList(KeywordQueryPageRequest request);
    }
}