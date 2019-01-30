using Spark.Core.Values;

namespace Spark.Config.Api.DTOs.User
{
    public class QueryUserRequest : QueryByPageRequest
    {
        public string Mobile { get; set; }
    }
}