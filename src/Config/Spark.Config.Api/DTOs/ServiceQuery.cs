using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTOs
{
    public class ServiceQuery
    {
        [Required]
        public string App { get; set; }

        public int Status { get; set; } = 1;
    }
}