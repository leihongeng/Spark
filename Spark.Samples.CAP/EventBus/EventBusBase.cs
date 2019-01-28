using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Spark.Samples.CAP.EventBus
{
    public abstract class EventBusBase : IEventBus
    {
        public void Publish<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TEventData>(IEventHandler eventHandler) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }

        public void SubscribeAllEventHandlerFromAssembly(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public void UnSubscribe<TEventData>(Type handlerType) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }
    }
}