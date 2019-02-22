using Spark.Core.Values;

namespace Spark.Config.Api.DTO.Sms
{
    public class SmsTempSearchRequest : KeywordQueryPageRequest
    {
        public string AppCode { get; set; }

        public long UserId { get; set; }

        public int IsAdmin { get; set; }
    }
}