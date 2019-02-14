namespace Spark.Core.Values
{
    public class QueryPageResponse<T> : QueryResponse<T>
    {
        public long Total { get; set; }
    }
}