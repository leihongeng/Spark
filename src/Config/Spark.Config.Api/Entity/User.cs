namespace Spark.Config.Api.Entity
{
    public class User : BaseEntity
    {
        public string Mobile { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int IsDelete { get; set; }
    }
}