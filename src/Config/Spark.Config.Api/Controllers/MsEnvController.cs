using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Core.Values;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Spark.Config.Api.Controllers
{
    public class MsEnvController : BaseController
    {
        public IMsEnvRepository MsEnvRepository { get; }

        public MsEnvController(IMsEnvRepository msEnvRepository)
        {
            MsEnvRepository = msEnvRepository;
        }

        [HttpGet]
        public BaseResponse<MsEnv> GetById(int id)
        {
            var data = MsEnvRepository.GetById(id);

            return new BaseResponse<MsEnv>(data);
        }

        [HttpPost]
        public BaseResponse<int> Insert([FromBody]MsEnv MsEnv)
        {
            var result = MsEnvRepository.Insert(MsEnv);

            return new BaseResponse<int>(result);
        }

        [HttpPost]
        public BaseResponse<int> DeleteById([FromBody]int id)
        {
            var result = MsEnvRepository.DeleteById(id);

            return new BaseResponse<int>(result);
        }

        [HttpPost]
        public BaseResponse<int> Update([FromBody]MsEnv MsEnv)
        {
            var result = MsEnvRepository.Update(MsEnv);

            return new BaseResponse<int>(result);
        }

        [HttpPost]
        public BaseResponse<IEnumerable<MsEnv>> Query()
        {
            var result = MsEnvRepository.Query(null);

            return new BaseResponse<IEnumerable<MsEnv>>(result);
        }

        [HttpPost]
        public BaseResponse<QueryByPageResponse<MsEnv>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var result = MsEnvRepository.QueryPaged(reqMsg);

            return new BaseResponse<QueryByPageResponse<MsEnv>>(result);
        }
    }
}