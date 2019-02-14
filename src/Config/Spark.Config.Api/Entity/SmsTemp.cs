using System;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///SmsTemp
    ///</summary>
    public class SmsTemp
    {
        public SmsTemp()
        {
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            IsDelete = 0;
        }

        ///<summary>
        ///
        ///</summary>
        public long Id { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string AppCode { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long AppId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TempCode { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Content { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int IsDelete { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? AddTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? UpdateTime { get; set; }
    }
}