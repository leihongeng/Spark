using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.WeiXinSdk.Mass
{
    public abstract class ToUserMess : BaseMess
    {
        public List<string> touser { get; set; }
    }
}
