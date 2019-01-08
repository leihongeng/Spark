using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.Core
{
    public interface IJsonHelper
    {
        string SerializeObject(object value);

        T DeserializeObject<T>(string value);
    }
}