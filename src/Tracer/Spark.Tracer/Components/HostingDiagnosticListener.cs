using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Spark.AspNetCore.Diagnostics;
using Microsoft.Extensions.DiagnosticAdapter;

namespace Spark.Tracer.Components
{
    public class HostingDiagnosticListener : IDiagnosticProcessListener
    {
        private readonly IOptions<TracingOptions> _options;

        public HostingDiagnosticListener(IOptions<TracingOptions> options)
        {
            _options = options;
        }

        public string ListenerName { get; } = "Microsoft.AspNetCore";

        [DiagnosticName("Microsoft.AspNetCore.Hosting.BeginRequest")]
        public void BeginRequest(HttpContext httpContext)
        {
        }

        [DiagnosticName("Microsoft.AspNetCore.Hosting.EndRequest")]
        public void EndRequest(HttpContext httpContext)
        {
        }

        [DiagnosticName("Microsoft.AspNetCore.Diagnostics.HandledException")]
        public void DiagnosticHandledException(HttpContext httpContext, Exception exception)
        {
        }

        [DiagnosticName("Microsoft.AspNetCore.Diagnostics.UnhandledException")]
        public void DiagnosticUnhandledException(HttpContext httpContext, Exception exception)
        {
        }

        [DiagnosticName("Microsoft.AspNetCore.Hosting.UnhandledException")]
        public void HostingUnhandledException(HttpContext httpContext, Exception exception)
        {
        }
    }
}