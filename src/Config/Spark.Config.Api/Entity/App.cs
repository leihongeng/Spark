using System;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///App
    ///</summary>
    public class App
    {
        public App()
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
        public string Code { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Remark { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Status { get; set; }

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