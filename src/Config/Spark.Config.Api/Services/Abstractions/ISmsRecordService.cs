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
    public interface ISmsRecordService
    {
        long Insert(SmsRecord smsRecord);

        int Delete(object reqParams);

        int DeleteById(long id);

        int Update(SmsRecord smsRecord);

        int DyUpdate(object dyObj);

        SmsRecord GetEntity(object reqParams);

        int GetRecord(object reqParams);

        bool IsExist(object reqParams);

        IEnumerable<SmsRecord> Query(object reqParams);

        IEnumerable<SmsRecord> QueryByPage(object reqParams);

        QueryByPageResponse<SmsRecord> QueryPaged(object reqParams);
    }
}