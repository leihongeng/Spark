using Spark.Core.Values;

namespace Spark.Config.Api.DTOs.App
{
    public class QueryAppRequest : QueryByPageRequest
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}