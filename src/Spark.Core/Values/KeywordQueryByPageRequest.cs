using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.Core.Values
{
    public class KeywordQueryByPageRequest : QueryByPageRequest
    {
        public string Keyword { get; set; }
    }
}