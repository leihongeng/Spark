using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.AspNetCore
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Use(async (context, _next) =>
                {
                    context.Response.Headers.Add("Server", "Spark Server");

                    await _next();
                });
                next(app);
            };
        }
    }
}