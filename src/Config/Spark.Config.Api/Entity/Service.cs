namespace Spark.Config.Api.Entity
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }

        public string Ip { get; set; }

        public int Port { get; set; }

        public int Status { get; set; }

        public string Remark { get; set; }

        public string AppCode { get; set; }

        public long AppId { get; set; }
    }
}