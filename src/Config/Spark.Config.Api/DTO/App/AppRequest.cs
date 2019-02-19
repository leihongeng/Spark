using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTO.App
{
    public class AppRequest
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Code不能为空！")]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "名称不能为空！")]
        public string Name { get; set; }

        public string Remark { get; set; }

        public int Status { get; set; }
    }
}