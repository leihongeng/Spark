using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spark.AspNetCore.Middleware
{
    internal class HttpMethodMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpMethodMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method.ToLower() == "options")
            {
                context.Response.StatusCode = StatusCodes.Status202Accepted;
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,OPTIONS,DELETE");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type,Authorization");
                await context.Response.WriteAsync("");
            }
            else
            {
                await _next(context);
            }
        }
    }
}