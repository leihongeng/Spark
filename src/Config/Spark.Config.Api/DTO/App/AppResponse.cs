using System;

namespace Spark.Config.Api.DTO.App
{
    public class AppResponse
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public int? Status { get; set; }

        public DateTime? AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}