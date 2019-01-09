using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.WeiXinSdk
{
    public class ReturnCode
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public override string ToString()
        {
            return "{ \"errcode\":" + errcode + ",\"errmsg\":\"" + errmsg + "\"}";
        }
    }
}
