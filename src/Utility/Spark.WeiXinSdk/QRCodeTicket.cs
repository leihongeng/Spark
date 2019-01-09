using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.WeiXinSdk
{
    /// <summary>
    /// 创建二维码ticket
    /// </summary>
    public class QRCodeTicket
    {
        public string ticket { get; set; }
        public int expire_seconds { get; set; }

        public string url { get; set; }

        public ReturnCode error { get; set; }
    }
}
