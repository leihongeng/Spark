using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Spark.AspNetCore.Diagnostics;
using Microsoft.Extensions.DiagnosticAdapter;

namespace Spark.Tracer.Components
{
    public class HttpClientDiagnosticListener : IDiagnosticProcessListener
    {
        private static Regex _tbbrRegex = new Regex(@"\s*|\t|\r|\n", RegexOptions.IgnoreCase);

        private readonly TracingOptions _options;

        public HttpClientDiagnosticListener(IOptions<TracingOptions> options)
        {
            _options = options.Value;
        }

        public string ListenerName { get; } = "HttpHandlerDiagnosticListener";

        [DiagnosticName("System.Net.Http.Request")]
        public void HttpRequest(HttpRequestMessage request)
        {
        }

        [DiagnosticName("System.Net.Http.Response")]
        public void HttpResponse(HttpResponseMessage response)
        {
        }

        [DiagnosticName("System.Net.Http.Exception")]
        public void HttpException(HttpRequestMessage request, Exception ex)
        {
        }
    }
}