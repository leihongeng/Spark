using System;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///User
    ///</summary>
    public class User
    {
        public User()
        {
            IsDelete = 0;
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
        public string Mobile { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string UserName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Password { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsDelete { get; set; }

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