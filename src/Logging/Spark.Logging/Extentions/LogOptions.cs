using Spark.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.Logging
{
    public class LogOptions
    {
        public LogOptions()
        {
            Extensions = new List<IOptionsExtension>();
        }

        internal IList<IOptionsExtension> Extensions { get; }

        public void RegisterExtension(IOptionsExtension extension)
        {
            if (extension == null)
                throw new ArgumentNullException(nameof(extension));

            Extensions.Add(extension);
        }
    }
}