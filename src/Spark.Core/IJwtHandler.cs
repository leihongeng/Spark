using Spark.Core.Values;
using System.Collections.Generic;
using System.Security.Claims;

namespace Spark.Core
{
    public interface IJwtHandler
    {
        JsonWebToken Create(long uid, List<Claim> claims = null, string scope = null);
    }
}