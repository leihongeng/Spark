//*******************************
// Create By Wwb
// Date 2019-01-30 11:15
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************
using System;

namespace Fruit.Entity
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