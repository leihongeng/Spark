using System;
using System.Collections.Generic;
using Spark.Config.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Core.Values;

namespace Spark.Config.Api.Controllers
{
    /// <summary>
    /// 应用接口
    /// </summary>
    public class AppController : BaseController
    {
        public IMsAppRepository _appRepository { get; }

        public AppController(IMsAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [HttpPost]
        public BaseResponse<IEnumerable<MsApp>> Query()
        {
            var result = _appRepository.Query(null);

            return new BaseResponse<IEnumerable<MsApp>>(result);
        }

        [HttpPost]
        public BaseResponse<QueryByPageResponse<MsApp>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var result = _appRepository.QueryPaged(reqMsg);

            return new BaseResponse<QueryByPageResponse<MsApp>>(result);
        }

        [HttpGet]
        public IActionResult GetAppList()
        {
            return Json(_appRepository.Query(new { }));
        }

        [HttpPost]
        public IActionResult SaveApp(MsApp model)
        {
            if (model.Id == 0)
            {
                _appRepository.Insert(model);
            }
            else
            {
                _appRepository.DyUpdate(new
                {
                    model.Id,
                    model.Name,
                    model.Remark,
                    model.Code,
                    UpdateTime = DateTime.Now
                });
            }
            return Json();
        }

        [HttpPost]
        public IActionResult DeleteApp(BaseModel model)
        {
            return Json(_appRepository.Delete(model));
        }
    }
}