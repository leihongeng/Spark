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
    public interface IAppService
    {
        long Insert(App app);

        int Delete(object reqParams);

        int DeleteById(long id);

        int Update(App app);

        int DyUpdate(object dyObj);

        App GetEntity(object reqParams);

        int GetRecord(object reqParams);

        bool IsExist(object reqParams);

        IEnumerable<App> Query(object reqParams);

        IEnumerable<App> QueryByPage(object reqParams);

        QueryByPageResponse<App> QueryPaged(object reqParams);
    }
}