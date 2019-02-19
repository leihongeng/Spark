using System;

namespace Spark.Config.Api.DTO.Sms
{
    public class SmsTempResponse
    {
        public long Id { get; set; }

        public string AppName { get; set; }

        public string Name { get; set; }

        public int? Status { get; set; }

        public string Content { get; set; }

        public DateTime? AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}