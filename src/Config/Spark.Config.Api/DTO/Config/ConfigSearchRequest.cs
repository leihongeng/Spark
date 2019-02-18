using Spark.Core.Values;

namespace Spark.Config.Api.DTO.Config
{
    public class ConfigSearchRequest : KeywordQueryPageRequest
    {
        public long UserId { get; set; }

        public int IsAdmin { get; set; }
    }
}