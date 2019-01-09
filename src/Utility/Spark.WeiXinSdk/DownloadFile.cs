using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spark.WeiXinSdk
{
    public class DownloadFile
    {
        public Stream Stream { get; set; }

        /// <summary>
        ///  image/jpeg等
        /// </summary>
        public string ContentType { get; set; }

        public ReturnCode error { get; set; }
    }
}