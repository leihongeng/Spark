using System;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///SmsRecord
    ///</summary>
    public class SmsRecord
    {
        public SmsRecord()
        {
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            Status = 0;
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
        public string Mobile { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Content { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? Status { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? AddTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}