using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Spark.AspNetCore;
using Spark.Config.Api.AppCode;
using Spark.Config.Api.Services.Abstractions;
using Spark.Config.Api.Services.Implements;
using Spark.Elasticsearch;
using Spark.SmartSqlConfig;
using Spark.Swagger;
using Swashbuckle.AspNetCore.Swagger;

namespace Spark.Config.Api
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
            services.AddAutoMapper(y => { y.AddProfile<MappingProfile>(); });
            services.AddCors(options => options.AddPolicy("CorsPolicy"
                , (builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials())));

            //添加火花
            services.AddSpark(builder =>
            {
                builder
                    .AddAuthentication(Configuration)
                    .AddJwtHandler(Configuration)
                    .AddElasticesearch(Configuration)
                    .AddSwagger(option =>
                    {
                        option.Add("v1", new Info { Title = "Spark", Version = "v1", Description = "https://guodaxia.com/" });
                    }, "Spark.Config.Api")
                    .AddSmartSql("Spark.Config.Api"); //添加SmartSql数据库支持
                //.AddEventBus(x => { }) //添加消息总线
                //.AddLog(x => x.UseEventBusLog(Configuration));
            });

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            RegisterService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseAuthentication()
                .UseGlobalErrorMiddleware()
                .UseHttpMethodMiddleware()
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/Spark.Config.Api/swagger/v1/swagger.json", "SparkAPI");
                })
                .UseCors("CorsPolicy")
                //mvc
                .UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });
        }

        private void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IAccountServices, AccountServices>();
            services.AddTransient<IAppServices, AppServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<ISmsServices, SmsServices>();
            services.AddTransient<IConfigServices, ConfigServices>();
            services.AddTransient<IApiServices, ApiServices>();
            services.AddSingleton<IPower, Power>();
        }
    }
}