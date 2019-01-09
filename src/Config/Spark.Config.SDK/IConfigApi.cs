using Spark.Config.SDK.DTOs;
using Spark.Config.SDK.Entity;
using Spark.Core.Values;
using System.Collections.Generic;
using WebApiClient;
using WebApiClient.Attributes;

namespace Spark.Config.SDK
{
    [HttpHost("http://192.168.0.198:6000")]
    public interface IConfigApi : IHttpApi
    {
        [HttpPost("/config/MsService/Query")]
        ITask<BaseResponse<List<MsService>>> ServiceQuery([JsonContent] MsServiceQuery request);

        [HttpPost("/config/MsConfig/Query")]
        ITask<BaseResponse<MsConfig>> ConfigQuery([JsonContent] MsConfigQuery request);
    }
}