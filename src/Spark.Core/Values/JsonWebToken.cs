using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.Core.Values
{
    public class JsonWebToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public long expires_in { get; set; }
    }
}