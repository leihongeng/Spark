using System;
using System.Collections.Generic;
using Spark.Config.Api.DTOs;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Core.Values;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Spark.Config.Api.Controllers
{
    public class MsConfigController : BaseController
    {
        private readonly IMsConfigRepository _configRepository;

        public MsConfigController(IMsConfigRepository msConfigRepository
         , IMsAppRepository msAppRepository)
        {
            _configRepository = msConfigRepository;
        }

        [HttpPost]
        public IActionResult Query(ConfigQuery request)
        {
            var result = _configRepository.GetEntity(request);
            if (!request.UpdateTime.HasValue || result.UpdateTime > request.UpdateTime)
            {
                return Json(result);
            }
            return Json();
        }

        [HttpPost]
        public BaseResponse<QueryByPageResponse<MsConfig>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var result = _configRepository.QueryPaged(reqMsg);

            return new BaseResponse<QueryByPageResponse<MsConfig>>(result);
        }

        [HttpGet]
        public IActionResult GetConfigList([FromQuery]QueryByPageRequest model)
        {
            var result = _configRepository.GetList(model);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SaveConfig(MsConfig model)
        {
            if (model.Id == 0)
            {
                _configRepository.Insert(model);
            }
            else
            {
                _configRepository.DyUpdate(new
                {
                    model.Id,
                    model.Key,
                    Value = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<Dictionary<string, object>>(model.Value)),
                    model.Status,
                    model.App,
                    UpdateTime = DateTime.Now
                });
            }
            return Json();
        }

        [HttpPost]
        public IActionResult DeleteConfig(BaseModel model)
        {
            return Json(_configRepository.Delete(model));
        }
    }
}