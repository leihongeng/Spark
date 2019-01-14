using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Authorisation;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Remote;

namespace Spark.Samples.ApiGateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot().AddRemoteServiceDiscovery();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var conf = new OcelotPipelineConfiguration()
            {
                // 健康检查地址
                PreErrorResponderMiddleware = async (ctx, next) =>
                {
                    if (ctx.HttpContext.Request.Path.Equals(new PathString("/status")))
                    {
                        await ctx.HttpContext.Response.WriteAsync("ok");
                    }
                    else
                    {
                        await next.Invoke();
                    }
                },
                //JWT认证扩展
                AuthorisationMiddleware = async (ctx, next) =>
                {
                    //用户权限判断，Token里携带Scope，如何包含则有权限
                    if (ctx.DownstreamReRoute.IsAuthenticated && ctx.DownstreamReRoute.AuthenticationOptions.AllowedScopes.Count > 0)
                    {
                        var claim = ctx.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Scope");
                        if (claim != null && ctx.DownstreamReRoute.AuthenticationOptions.AllowedScopes.Contains(claim.Value))
                        {
                            await next.Invoke();
                        }
                        else
                        {
                            ctx.Errors.Add(new UnauthorisedError($"{ctx.HttpContext.User.Identity.Name} is not authorised to access {ctx.DownstreamReRoute.UpstreamPathTemplate.OriginalValue}"));
                        }
                    }
                    else
                    {
                        await next.Invoke();
                    }
                }
            };

            // 使用网关
            app.UseOcelot(conf).Wait();
        }
    }
}