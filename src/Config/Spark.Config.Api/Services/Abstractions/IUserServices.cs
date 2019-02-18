using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.User;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IUserServices
    {
        QueryPageResponse<UserResponse> LoadList(KeywordQueryPageRequest request);

        void Save(UserRequest request);

        void Remove(BaseRequest request);
    }
}