using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTO.User
{
    public class UserRequest
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "手机号码不能为空！")]
        public string Mobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "账号不能为空！")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "密码不能为空！")]
        public string Password { get; set; }

        public int Status { get; set; }
    }
}