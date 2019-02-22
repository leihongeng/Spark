using Spark.Core.Values;

namespace Spark.Config.Api.DTO.App
{
    public class AppSearchRequest : KeywordQueryPageRequest
    {
        public int IsAdmin { get; set; }

        public long UserId { get; set; }
    }
}