using System;

namespace Spark.Config.Api.DTO.Service
{
    public class ApiServiceResponse
    {
        public long Id { get; set; }

        public string AppName { get; set; }

        public string Name { get; set; }

        public string Ip { get; set; }

        public string Port { get; set; }

        public int Status { get; set; }

        public string Remark { get; set; }

        public DateTime? AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}