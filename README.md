# spark
spark是一个基于netcore的分布式微服务框架。spark有星火的意思，意义为星星之火可以燎原。

# demo
```
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
            //添加认证
            .AddAuthentication(Configuration)
            //添加SmarkSql数据库支持
            .AddSmartSql()
            //添加消息总线
            .AddEventBus(x => { })
            //负载均衡
            .AddLoadBalancer()
            //服务发现
            .AddServiceDiscovery(x => x.UseRemote(Configuration))
            //添加分布式日志
            .AddLog(x => x.UseEventBusLog(Configuration))
            //添加检索引擎
            .AddElasticesearch(Configuration);
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
        // 日志
        loggerFactory.AddSparkLog(app, "Spark.Samples.WebApi");

        app
            .UseGlobalErrorMiddleware()
            .UseHttpMethodMiddleware()
            .UseStatisticsMiddleware()
            .UseAuthentication();

        app.UseMvc();
    }
}
 ```
# 配置中心demo
```
public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(
                (hostingContext, builder) =>
                {
                    //获取全局变量
                    builder.AddRemoteConfig(
                        options =>
                        {
                            options.App = "TestApp";
                            options.Key = "GlobalConfig";
                            options.Optional = true;
                            options.ReloadOnChange = true;
                            options.Url = Environment.GetEnvironmentVariable("ConfigUrl");
                            options.Interval = 10000;
                        });
                })
            .ConfigureLogging(
                (hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("GlobalConfig:Logging"));
                })
            .UseStartup<Startup>();
}
```
