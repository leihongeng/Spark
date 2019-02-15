using System;

namespace Spark.Config.Api.DTO.Sms
{
    public class SmsRecordResponse
    {
        public long Id { get; set; }

        public string TempCode { get; set; }

        public string Mobile { get; set; }

        public string Content { get; set; }

        public int Status { get; set; }

        public string AppName { get; set; }

        public DateTime? AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}