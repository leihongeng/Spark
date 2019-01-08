using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Spark.AspNetCore.Diagnostics
{
    public class DiagnosticListenerObserver : IObserver<DiagnosticListener>
    {
        private readonly IEnumerable<IDiagnosticProcessListener> _listeners;

        public DiagnosticListenerObserver(IEnumerable<IDiagnosticProcessListener> listeners)
        {
            _listeners = listeners;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(DiagnosticListener value)
        {
            var list = _listeners.ToList().Where(x => x.ListenerName == value.Name).ToList();
            foreach (var para in list)
            {
                value.SubscribeWithAdapter(para);
            }
        }
    }
}