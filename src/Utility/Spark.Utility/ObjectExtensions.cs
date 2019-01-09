using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Spark.Utility
{
    public static class ObjectExtensions
    {
        public static Dictionary<string, object> ToDictionary(this object obj)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var item in properties)
            {
                dic.Add(item.Name, item.GetValue(obj));
            }
            return dic;
        }
    }
}