using SmartSql.DyRepository;
using Spark.Config.Api.DTO.Sms;
using Spark.Config.Api.Entity;
using Spark.Core.Values;

namespace Spark.Config.Api.Repository
{
    public interface ISmsRepository : IRepository
    {
        QueryPageResponse<SmsTempResponse> GetTempList(SmsTempSearchRequest request);

        QueryPageResponse<SmsRecordResponse> GetRecordList(SmsRecordSearchRequest request);

        void InsertTemp(SmsTemp temp);

        void UpdateTemp(object temp);
    }
}