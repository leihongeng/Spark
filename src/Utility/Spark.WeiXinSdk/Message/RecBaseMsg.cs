using System;

namespace Spark.WeiXinSdk.Message
{
    public abstract class RecBaseMsg : RecEventBaseMsg
    {
        /// <summary>
        /// 消息id
        /// </summary>
        public Int64 MsgId { get; set; }
    }
}