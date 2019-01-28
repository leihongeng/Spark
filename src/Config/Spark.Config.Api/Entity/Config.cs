namespace Spark.Config.Api.Entity
{
    public class Config : BaseEntity
    {
        public string App { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public int Status { get; set; }
    }
}