using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTO.Service
{
    public class ApiServiceRequest
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "项目不能为空！")]
        public string AppCode { get; set; }

        public int Status { get; set; } = 1;

        [Required(AllowEmptyStrings = false, ErrorMessage = "服务名称不能为空！")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ip地址不能为空！")]
        public string Ip { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "端口不能为空！")]
        public string Port { get; set; }

        public string Remark { get; set; }
    }
}