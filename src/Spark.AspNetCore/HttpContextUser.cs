using Microsoft.AspNetCore.Http;
using Spark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Spark.AspNetCore
{
    public class HttpContextUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long Id => long.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "0");

        public string Name => _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Name").Value;

        public string MobilePhone => _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.MobilePhone).Value;

        public IEnumerable<Claim> Claims => _httpContextAccessor.HttpContext.User.Claims;

        public int UserType => int.Parse(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(s => s.Type == "UserType").Value);
    }
}