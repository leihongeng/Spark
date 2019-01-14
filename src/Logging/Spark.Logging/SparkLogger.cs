using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;

namespace Spark.Logging
{
    public class SparkLogger : ILogger
    {
        private readonly ILogStore _logStore;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _appName;
        private readonly string _projectName;

        private readonly string _categoryName;

        public SparkLogger(ILogStore logStore, IHttpContextAccessor httpContextAccessor, string appName, string projectName, string categoryName)
        {
            _logStore = logStore;
            _httpContextAccessor = httpContextAccessor;
            _appName = appName;
            _projectName = projectName;
            _categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            string message = string.Empty;
            if (formatter != null)
            {
                message = formatter(state, exception);
            }

            var entry = new LogEntry
            {
                EventId = eventId,
                DateTime = DateTime.UtcNow,
                AppName = _appName,
                ProjectName = _projectName,
                Category = _categoryName,
                Message = message,
                Level = logLevel
            };

            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                entry.TraceIdentifier = context.TraceIdentifier;
                entry.UserName = context.User.Identity.Name;
                var request = context.Request;
                entry.ContentLength = request.ContentLength;
                entry.ContentType = request.ContentType;
                entry.Host = request.Host.Value;
                entry.IsHttps = request.IsHttps;
                entry.Method = request.Method;
                entry.Path = request.Path;
                entry.PathBase = request.PathBase;
                entry.Protocol = request.Protocol;
                entry.QueryString = request.QueryString.Value;
                entry.Scheme = request.Scheme;
                //entry.Cookies = request.Cookies;
                //entry.Headers = request.Headers;
            }

            if (exception != null)
            {
                entry.Exception = exception.ToString();
                entry.ExceptionMessage = exception.Message;
                entry.ExceptionType = exception.GetType().Name;
                entry.StackTrace = exception.StackTrace;
            }

            GetRequestBody(entry);

            _logStore.Post(entry);
        }

        private async void GetRequestBody(LogEntry entry)
        {
            try
            {
                var context = _httpContextAccessor.HttpContext;
                if (context?.Request?.Body?.Length > 0)
                {
                    context.Request.Body.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                    {
                        var body = await reader.ReadToEndAsync();
                        entry.Body = body;
                        context.Request.Body.Seek(0, SeekOrigin.Begin);
                    }
                }
            }
            catch
            {
            }
        }
    }
}