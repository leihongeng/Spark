using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore.Diagnostics;
using Spark.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSpark(this IServiceCollection services, Action<SparkBuilder> setupAction)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUser, HttpContextUser>();
            services.AddSingleton<IRequestScopedDataRepository, HttpDataRepository>();
            //事件
            services.AddHostedService<DiagnosticHostedService>();
            services.AddSingleton<DiagnosticListenerObserver>();
            //注册通用中间件
            services.AddSingleton<IStartupFilter, StartupFilter>();

            var builder = new SparkBuilder(services);
            setupAction?.Invoke(builder);

            return services;
        }
    }
}