using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.AspNetCore.Diagnostics
{
    /// <summary>
    /// 消息处理
    /// </summary>
    public interface IDiagnosticProcessListener
    {
        string ListenerName { get; }
    }
}