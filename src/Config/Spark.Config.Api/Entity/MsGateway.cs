//*******************************
// Create By Wwb
// Date 2018-11-07 13:42
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************
using System;
using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///MsGateway
    ///</summary>
    public class MsGateway
    {
        ///<summary>
        ///
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string App { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required]
        public string Name { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Ip { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int Port { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime AddTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime UpdateTime { get; set; }
    }
}