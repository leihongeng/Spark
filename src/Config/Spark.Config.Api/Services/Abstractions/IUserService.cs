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
    public interface IUserService
    {
        long Insert(User user);

        int Delete(object reqParams);

        int DeleteById(long id);

        int Update(User user);

        int DyUpdate(object dyObj);

        User GetEntity(object reqParams);

        int GetRecord(object reqParams);

        bool IsExist(object reqParams);

        IEnumerable<User> Query(object reqParams);

        IEnumerable<User> QueryByPage(object reqParams);

        QueryByPageResponse<User> QueryPaged(object reqParams);
    }
}