﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spark.Samples.CAP.Internal
{
    public class CapSubscribeAttribute : TopicAttribute
    {
        public CapSubscribeAttribute(string name)
             : base(name)
        {
        }
    }
}