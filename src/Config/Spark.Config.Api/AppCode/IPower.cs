namespace Spark.Config.Api.AppCode
{
    public interface IPower
    {
        int IsAdmin { get; }

        long UserId { get; }
    }
}