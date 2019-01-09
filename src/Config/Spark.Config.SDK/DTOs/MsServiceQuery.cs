using System.ComponentModel.DataAnnotations;

namespace Spark.Config.SDK.DTOs
{
    public class MsServiceQuery
    {
        [Required]
        public string App { get; set; }
    }
}