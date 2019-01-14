using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace Spark.Logging
{
    public class SparkLogProvider : ILoggerProvider
    {
        private readonly string _projectName;
        private readonly string _appName;
        private readonly ConcurrentDictionary<string, SparkLogger> _loggers = new ConcurrentDictionary<string, SparkLogger>();
        private readonly ILogStore _logStore;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SparkLogProvider(ILogStore logStore, IHttpContextAccessor httpContextAccessor, string appName, string projectName)
        {
            _logStore = logStore;
            _projectName = projectName;
            _appName = appName;
            _httpContextAccessor = httpContextAccessor;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return this._loggers.GetOrAdd(categoryName, p => { return new SparkLogger(_logStore, _httpContextAccessor, _appName, _projectName, categoryName); });
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}