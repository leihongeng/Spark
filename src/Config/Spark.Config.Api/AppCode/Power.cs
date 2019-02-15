using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Spark.Config.Api.AppCode
{
    public class Power : IPower
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Power(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int IsAdmin => int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(s => s.Type == "IsAdmin")?.Value);
    }
}