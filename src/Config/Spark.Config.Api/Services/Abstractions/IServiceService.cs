//*******************************
// Create By Wwb
// Date 2019-01-30 11:15
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************
using Fruit.Entity;
using Spark.Core.Values;
using System.Collections.Generic;

namespace Fruit.IService
{
    public interface IServiceService
    {
        long Insert(Service service);

        int Delete(object reqParams);

        int DeleteById(long id);

        int Update(Service service);

        int DyUpdate(object dyObj);

        Service GetEntity(object reqParams);

        int GetRecord(object reqParams);

        bool IsExist(object reqParams);

        IEnumerable<Service> Query(object reqParams);

        IEnumerable<Service> QueryByPage(object reqParams);

        QueryByPageResponse<Service> QueryPaged(object reqParams);
    }
}