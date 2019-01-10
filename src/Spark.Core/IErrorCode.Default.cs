using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Core
{
    public class EmptyErrorCode : IErrorCode
    {
        public EmptyErrorCode()
        {
        }

        public string StringGet(string code)
        {
            return string.Empty;
        }

        public Task<string> StringGetAsync(string code)
        {
            return Task.FromResult(string.Empty);
        }
    }
}