using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.AspNetCore
{
    public class SparkOptions
    {
        internal IList<IOptionsExtension> Extensions { get; }

        public SparkOptions()
        {
            Extensions = new List<IOptionsExtension>();
        }

        public void RegisterExtension(IOptionsExtension extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            Extensions.Add(extension);
        }
    }
}