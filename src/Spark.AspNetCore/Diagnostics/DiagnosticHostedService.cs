using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spark.AspNetCore.Diagnostics
{
    /// <summary>
    /// 启动跟踪
    /// </summary>
    public class DiagnosticHostedService : IHostedService
    {
        private readonly DiagnosticListenerObserver _diagnosticObserver;

        private ILogger<DiagnosticHostedService> _logger;

        public DiagnosticHostedService(DiagnosticListenerObserver diagnosticObserver, ILoggerFactory loggerFactory)
        {
            _diagnosticObserver = diagnosticObserver;
            _logger = loggerFactory.CreateLogger<DiagnosticHostedService>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                DiagnosticListener.AllListeners.Subscribe(_diagnosticObserver);
            }
            catch (Exception e)
            {
                _logger.LogError("TracingHostedService Start Fail.", e);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}