using System;
using System.ComponentModel.DataAnnotations;

namespace Spark.Config.SDK.DTOs
{
    public class MsConfigQuery
    {
        [Required]
        public string App { get; set; }

        public string Key { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}