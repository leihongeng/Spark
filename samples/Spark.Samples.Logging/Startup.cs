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
using Spark.EventBus.Extensions;
using Spark.EventBus.RabbitMQ;
using Spark.Logging;
using Spark.Logging.EventBusStore.Extentions;

namespace Spark.Samples.Logging
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
            //添加火花
            services.AddSpark(builder =>
            {
                builder
                //添加消息总线
                .AddEventBus(x => x.UseRabbitMQ(Configuration))
                //添加分布式日志
                .AddLog(x => x.UseEventBusLog(Configuration));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSparkLog();

            app.UseMvc();
        }
    }
}