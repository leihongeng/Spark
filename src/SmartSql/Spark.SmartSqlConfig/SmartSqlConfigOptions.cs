using SmartSql.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.SmartSqlConfig
{
    public class SmartSqlConfigOptions
    {
        public Settings Settings { get; set; }

        public List<SmartSqlMapSource> SmartSqlMaps { get; set; }

        public List<TypeHandler> TypeHandlers { get; set; }
    }
}