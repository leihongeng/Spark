using SmartSql.DyRepository;
using Spark.Config.Api.Entity;
using Spark.Core.Values;

namespace Spark.Config.Api.Repository
{
    public interface ISmsRecordRepository : IRepository<SmsRecord, long>
    {
        QueryPageResponse<SmsRecord> QueryPaged(object reqParams);
    }
}