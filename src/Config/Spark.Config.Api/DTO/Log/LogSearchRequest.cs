using System;

namespace Spark.Config.Api.DTO.Log
{
    public class LogSearchRequest
    {
        /// <summary>
        /// 1业务日志，2系统日志
        /// </summary>
        public int? LogType { get; set; }

        public int PageSize { get; set; } = 10;

        public int PageIndex { get; set; } = 1;

        public string Project { get; set; }

        public string Level { get; set; }

        public string UserName { get; set; }

        public string RequestPath { get; set; }

        public string Keywords { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}