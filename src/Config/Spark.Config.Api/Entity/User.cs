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
            Status = 1;
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            IsAdmin = 0;
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

        public int IsAdmin { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? Status { get; set; }

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