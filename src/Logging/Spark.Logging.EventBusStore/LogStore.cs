using Spark.EventBus.Abstractions;

namespace Spark.Logging.EventBusStore
{
    public class LogStore : ILogStore
    {
        private readonly IEventBus _eventBus;

        public LogStore(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Post(LogEntry logs)
        {
            _eventBus.Publish(new LogEvent(logs));
        }
    }
}