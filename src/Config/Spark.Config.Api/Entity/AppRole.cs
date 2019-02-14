using System;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///AppRole
    ///</summary>
    public class AppRole
    {
        public AppRole()
        {
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        ///<summary>
        ///
        ///</summary>
        public long Id { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long AppId { get; set; }

        ///<summary>
        ///
        ///</summary>
        public long? UserId { get; set; }

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