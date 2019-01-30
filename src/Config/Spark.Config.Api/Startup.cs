using Fruit.IService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spark.AspNetCore;
using Spark.Config.Api.Services.Implements;
using Spark.SmartSqlConfig;
using Spark.Swagger;
using Swashbuckle.AspNetCore.Swagger;

namespace Spark.Spark.Config.Api
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
                    .AddAuthentication(Configuration)
                    .AddJwtHandler(Configuration)
                    .AddSwagger(option =>
                    {
                        option.Add("v1", new Info { Title = "Spark", Version = "v1", Description = "https://guodaxia.com/" });
                    }, "Spark.Config.Api")
                    .AddSmartSql("Spark.Config.Api"); //添加SmartSql数据库支持
                //.AddEventBus(x => { }) //添加消息总线
                //.AddLog(x => x.UseEventBusLog(Configuration));
            });

            RegisterService(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SparkAPI");
                })
                //mvc
                .UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });
        }

        private void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAppService, AppService>();
        }
    }
}