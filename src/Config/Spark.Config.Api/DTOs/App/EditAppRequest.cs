using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spark.Config.Api.DTOs.App
{
    public class EditAppRequest
    {
        ///<summary>
        ///
        ///</summary>
        [Required]
        public string Code { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required]
        public string Name { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Remark { get; set; }
    }

    public class AddAppRequest : EditAppRequest
    {
    }
}