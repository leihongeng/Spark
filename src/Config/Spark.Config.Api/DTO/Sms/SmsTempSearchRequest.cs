using Spark.Core.Values;

namespace Spark.Config.Api.DTO.Sms
{
    public class SmsTempSearchRequest : KeywordQueryPageRequest
    {
        public long UserId { get; set; }

        public int IsAdmin { get; set; }
    }
}