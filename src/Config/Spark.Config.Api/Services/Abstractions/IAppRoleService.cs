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
    public interface IAppRoleService
    {
        long Insert(AppRole appRole);

        int Delete(object reqParams);

        int DeleteById(long id);

        int Update(AppRole appRole);

        int DyUpdate(object dyObj);

        AppRole GetEntity(object reqParams);

        int GetRecord(object reqParams);

        bool IsExist(object reqParams);

        IEnumerable<AppRole> Query(object reqParams);

        IEnumerable<AppRole> QueryByPage(object reqParams);

        QueryByPageResponse<AppRole> QueryPaged(object reqParams);
    }
}