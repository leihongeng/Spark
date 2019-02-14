using System.Collections.Generic;

namespace Spark.Core.Values
{
    public class QueryResponse<T>
    {
        public IEnumerable<T> List { get; set; }
    }
}