using System;
using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTO.Config
{
    public class ConfigLatestRequest
    {
        [Required]
        public string AppCode { get; set; }

        public string Key { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}