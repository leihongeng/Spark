using System;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///Config
    ///</summary>
    public class Config
    {
        public Config()
        {
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            Status = 1;
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
        public string Key { get; set; }

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
        public string Remark { get; set; }

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