using Spark.Core.Values;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Spark.Core
{
    public interface IJwtHandler
    {
        JsonWebToken Create(string username, List<Claim> claims = null, string scope = null);
    }
}