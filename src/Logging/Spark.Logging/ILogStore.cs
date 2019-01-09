namespace Spark.Logging
{
    public interface ILogStore
    {
        void Post(LogEntry logs);
    }
}