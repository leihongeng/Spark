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
    public interface ISmsTempService
    {
        long Insert(SmsTemp smsTemp);

        int Delete(object reqParams);

        int DeleteById(long id);

        int Update(SmsTemp smsTemp);

        int DyUpdate(object dyObj);

        SmsTemp GetEntity(object reqParams);

        int GetRecord(object reqParams);

        bool IsExist(object reqParams);

        IEnumerable<SmsTemp> Query(object reqParams);

        IEnumerable<SmsTemp> QueryByPage(object reqParams);

        QueryByPageResponse<SmsTemp> QueryPaged(object reqParams);
    }
}