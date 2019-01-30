//*******************************
// Create By Wwb
// Date 2019-01-30 11:15
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************
using Fruit.Entity;
using SmartSql.DyRepository;
using Spark.Core.Values;

namespace Fruit.Repository
{
    public interface IServiceRepository : IRepository<Service, long>
    {
        QueryByPageResponse<Service> QueryPaged(object reqParams);
    }
}