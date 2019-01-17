using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Spark.AspNetCore;
using Spark.SmartSqlConfig;
using Spark.EventBus.Extensions;
using Spark.Logging;
using Spark.Logging.EventBusStore.Extentions;
using Spark.LoadBalancer.Extensions;
using Spark.ServiceDiscovery.Extensions;
using Spark.ServiceDiscovery.Remote.Extensions;
using Spark.Elasticsearch;
using Spark.EventBus.RabbitMQ;
using Spark.Tracer.Extensions;

namespace Spark.Samples.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpark(builder =>
            {
                builder
                //添加认证
                .AddAuthentication(Configuration)
                //添加SmarkSql数据库支持
                .AddSmartSql()
                //添加消息总线
                .AddEventBus(x => x.UseRabbitMQ(Configuration))
                //负载均衡
                .AddLoadBalancer()
                //服务发现
                .AddServiceDiscovery(x => x.UseRemote(Configuration))
                //添加分布式日志
                .AddLog(x => x.UseEventBusLog(Configuration))
                //添加检索引擎
                .AddElasticesearch(Configuration)
                //添加链路追踪
                .AddTracer(Configuration);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSparkLog()
                .UseGlobalErrorMiddleware()
                .UseHttpMethodMiddleware()
                .UseStatisticsMiddleware()
                .UseAuthentication();

            app.UseMvc();
        }
    }
}