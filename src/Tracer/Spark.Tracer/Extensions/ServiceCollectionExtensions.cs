using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore;
using Spark.AspNetCore.Diagnostics;
using Spark.Tracer.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.Tracer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static SparkBuilder AddTracer(this SparkBuilder services, IConfiguration configuration)
        {
            //事件
            services.Services.AddHostedService<DiagnosticHostedService>();
            services.Services.AddSingleton<DiagnosticListenerObserver>();
            services.Services.AddSingleton<IDiagnosticProcessListener, HostingDiagnosticListener>();
            services.Services.AddSingleton<IDiagnosticProcessListener, HttpClientDiagnosticListener>();

            return services;
        }
    }
}