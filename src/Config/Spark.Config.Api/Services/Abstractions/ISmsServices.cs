using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Sms;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface ISmsServices
    {
        QueryPageResponse<SmsTempResponse> LoadTempList(SmsTempSearchRequest request);

        QueryPageResponse<SmsRecordResponse> LoadRecordList(SmsRecordSearchRequest request);

        void SaveTemp(SmsTempRequest request);

        void SetTempStatus(BaseRequest request);
    }
}