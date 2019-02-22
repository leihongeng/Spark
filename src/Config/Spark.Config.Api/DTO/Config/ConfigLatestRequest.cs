using System;
using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTO.Config
{
    public class ConfigLatestRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "AppCode不能为空！")]
        public string AppCode { get; set; }

        public string Key { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}