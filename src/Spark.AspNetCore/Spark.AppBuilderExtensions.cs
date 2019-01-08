using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.AspNetCore
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseSpark(this IApplicationBuilder app)
        {
            return app;
        }
    }
}