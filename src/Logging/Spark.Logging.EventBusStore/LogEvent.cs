using Spark.EventBus.Events;

namespace Spark.Logging.EventBusStore
{
    public class LogEvent : IntegrationEvent
    {
        public LogEvent(LogEntry logInfo)
        {
            this.LogInfo = logInfo;
        }

        public LogEntry LogInfo { get; set; }
    }
}