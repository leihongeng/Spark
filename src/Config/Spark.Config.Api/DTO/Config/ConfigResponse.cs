using System;

namespace Spark.Config.Api.DTO.Config
{
    public class ConfigResponse
    {
        public long Id { get; set; }

        public string AppName { get; set; }

        public string AppCode { get; set; }

        public long AppId { get; set; }

        public string Key { get; set; }

        public string Content { get; set; }

        public int Status { get; set; }

        public string Remark { get; set; }

        public DateTime? AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}