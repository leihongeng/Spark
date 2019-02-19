using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTO.Sms
{
    public class SmsTempRequest
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "短信名称不能为空！")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "模板Code不能为空！")]
        public string TempCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "短信模板内容不能为空！")]
        public string Content { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "项目Id不能为空！")]
        public long AppId { get; set; }

        public int Status { get; set; } = 1;
    }
}