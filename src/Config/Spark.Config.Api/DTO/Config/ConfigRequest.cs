using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTO.Config
{
    public class ConfigRequest
    {
        ///<summary>
        ///
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "项目不能为空！")]
        public string AppCode { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Key不能为空！")]
        public string Key { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "配置详情不能为空！")]
        public string Content { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int Status { get; set; } = 1;

        public string Remark { get; set; }
    }
}