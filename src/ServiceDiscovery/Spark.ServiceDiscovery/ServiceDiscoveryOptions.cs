using Spark.AspNetCore;
using System;
using System.Collections.Generic;

namespace Spark.ServiceDiscovery
{
    public class ServiceDiscoveryOptions
    {
        public ServiceDiscoveryOptions()
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