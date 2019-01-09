using System;
using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///MsConfig
    ///</summary>
    public class MsConfig
    {
        public MsConfig()
        {
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

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
        public string Key { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required]
        public string Value { get; set; }

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