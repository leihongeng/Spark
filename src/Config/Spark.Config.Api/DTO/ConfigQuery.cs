using System;
using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTOs
{
    public class ConfigQuery
    {
        [Required]
        public string App { get; set; }

        public string Key { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}