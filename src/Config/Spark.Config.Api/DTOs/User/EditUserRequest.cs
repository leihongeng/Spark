using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.DTOs.User
{
    public class EditUserRequest
    {
        ///<summary>
        ///
        ///</summary>
        [Required]
        public string Mobile { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required]
        public string UserName { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required]
        public string Password { get; set; }
    }

    public class AddUserRequest : EditUserRequest
    {
    }

    public class UpdateUserRequest : EditUserRequest
    {
        [Required]
        public long Id { get; set; }
    }
}