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
    ///MsEnv
    ///</summary>
    public class MsEnv
    {
        ///<summary>
        ///
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required]
        public string Name { get; set; }
    }
}