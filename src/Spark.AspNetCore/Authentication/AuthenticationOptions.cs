namespace Spark.AspNetCore.Authentication
{
    public class AuthenticationOptions
    {
        public string Secret { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public int ExpiryMinutes { get; set; }
        public string Scope { get; set; }
    }
}