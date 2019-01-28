using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spark.Samples.CAP.Internal
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public abstract class TopicAttribute : Attribute
    {
        protected TopicAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string Group { get; set; }
    }
}