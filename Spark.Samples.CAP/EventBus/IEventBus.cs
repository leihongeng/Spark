using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Spark.Samples.CAP.EventBus
{
    public interface IEventBus
    {
        void Subscribe<TEventData>(IEventHandler eventHandler) where TEventData : IEventData;

        void SubscribeAllEventHandlerFromAssembly(Assembly assembly);

        void UnSubscribe<TEventData>(Type handlerType) where TEventData : IEventData;

        void Publish<TEventData>(TEventData eventData) where TEventData : IEventData;

        Task PublishAsync<TEventData>(TEventData eventData) where TEventData : IEventData;
    }
}