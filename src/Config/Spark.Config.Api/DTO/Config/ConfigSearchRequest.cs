using Spark.Core.Values;

namespace Spark.Config.Api.DTO.Config
{
    public class ConfigSearchRequest : KeywordQueryPageRequest
    {
        public string AppCode { get; set; }

        public long UserId { get; set; }

        public int IsAdmin { get; set; }
    }
}