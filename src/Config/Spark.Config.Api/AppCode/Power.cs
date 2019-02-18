using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

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

        public long UserId => long.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "0");
    }
}