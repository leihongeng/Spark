namespace Spark.Config.Api.DTO.Service
{
    public class ApiServiceRequest
    {
        public long Id { get; set; }

        public long AppId { get; set; }

        public int Status { get; set; }

        public string Name { get; set; }

        public string Ip { get; set; }

        public string Port { get; set; }

        public string Remark { get; set; }
    }
}