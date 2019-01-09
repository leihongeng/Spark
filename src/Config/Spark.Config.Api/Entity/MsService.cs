using System;
using System.ComponentModel.DataAnnotations;

namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///MsService
    ///</summary>
    public class MsService
    {
        public MsService()
        {
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        ///<summary>
        ///
        ///</summary>
        public long Id { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name不能为空！")]
        public string Name { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ip不能为空！")]
        public string Ip { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Port不能为空！")]
        public int Port { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime AddTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime UpdateTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "App不能为空！")]
        public string App { get; set; }
    }
}