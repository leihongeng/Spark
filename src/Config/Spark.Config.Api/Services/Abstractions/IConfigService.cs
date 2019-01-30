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
    public interface IConfigService
    {
        long Insert(Config config);

        int Delete(object reqParams);

        int DeleteById(long id);

        int Update(Config config);

        int DyUpdate(object dyObj);

        Config GetEntity(object reqParams);

        int GetRecord(object reqParams);

        bool IsExist(object reqParams);

        IEnumerable<Config> Query(object reqParams);

        IEnumerable<Config> QueryByPage(object reqParams);

        QueryByPageResponse<Config> QueryPaged(object reqParams);
    }
}