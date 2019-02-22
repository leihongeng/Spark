using System;

namespace Spark.Config.Api.DTO.User
{
    public class UserResponse
    {
        public long Id { get; set; }

        public string Mobile { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int? Status { get; set; } = 0;

        public DateTime? AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}