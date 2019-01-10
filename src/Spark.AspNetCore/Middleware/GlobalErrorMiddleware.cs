using Micro.Core.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Spark.Core;
using Spark.Core.Values;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spark.AspNetCore.Middleware
{
    internal class GlobalErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IErrorCode _errorCodeStore;
        private readonly IHostingEnvironment _env;

        public GlobalErrorMiddleware(RequestDelegate next,
            ILoggerFactory loggerFactory,
            IHostingEnvironment env,
            IErrorCode errorCodeStore)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<GlobalErrorMiddleware>();
            _env = env;
            _errorCodeStore = errorCodeStore;
        }

        public async Task Invoke(HttpContext context)
        {
            ErrorResponse errorInfo = null;
            try
            {
                await _next(context);
            }
            catch (SparkException ex)
            {
                var newMsg = _errorCodeStore.StringGet(ex.ErrorCode);
                if (string.IsNullOrWhiteSpace(newMsg))
                    newMsg = ex.ErrorMessage;
                errorInfo = new ErrorResponse(ex.ErrorCode, newMsg);
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment() || _env.IsStaging())
                {
                    errorInfo = new ErrorResponse("-1", ex.Message);
                }
                else
                {
                    errorInfo = new ErrorResponse("-1", "系统开小差了,请稍后再试");
                }
                _logger.LogError(ex, $"全局异常捕获");
            }
            finally
            {
                if (errorInfo != null)
                {
                    var message = JsonConvert.SerializeObject(errorInfo);
                    await HandleExceptionAsync(context, message);
                }
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json;charset=utf-8";
            return context.Response.WriteAsync(message);
        }
    }
}