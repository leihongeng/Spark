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
    ///App
    ///</summary>
    public class App
    {
        public App()
        {
            AddTime = DateTime.Now;
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