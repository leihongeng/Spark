using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Spark.Core
{
    public interface IUser
    {
        long Id { get; }

        string Name { get; }

        string MobilePhone { get; }

        IEnumerable<Claim> Claims { get; }

        int UserType { get; }
    }
}