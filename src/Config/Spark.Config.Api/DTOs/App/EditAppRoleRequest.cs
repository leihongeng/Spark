using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spark.Config.Api.DTOs.App
{
    public class EditAppRoleRequest
    {
        ///<summary>
        ///
        ///</summary>
        [Required]
        public long AppId { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required]
        public long? UserId { get; set; }
    }

    public class AddAppRoleRequest : EditAppRoleRequest
    {
    }

    public class UpdateAppRoleRequest : EditAppRoleRequest
    {
        [Required]
        public long Id { get; set; }
    }
}