using Spark.Core.Values;

namespace Spark.Config.Api.DTO.Service
{
    public class ApiServiceSearchRequest : KeywordQueryPageRequest
    {
        public long UserId { get; set; }

        public int IsAdmin { get; set; }

        public string AppCode { get; set; }
    }
}