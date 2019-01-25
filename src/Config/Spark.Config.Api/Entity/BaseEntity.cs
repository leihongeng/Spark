using System;

namespace Spark.Config.Api.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            AddTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        public long Id { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}