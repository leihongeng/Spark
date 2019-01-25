using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSql.DyRepository;
using Spark.Config.Api.Entity;

namespace Spark.Config.Api.Repository
{
    public interface IUserRepository : IRepository<User, long>
    {
    }
}