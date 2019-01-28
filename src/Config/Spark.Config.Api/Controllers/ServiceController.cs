using Spark.Config.Api.DTOs;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Core.Values;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Spark.Config.Api.Controllers
{
    public class ServiceController : BaseController
    {
        public IMsServiceRepository _serviceRepository { get; }

        public ServiceController(IMsServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost]
        public IActionResult Query(ServiceQuery request)
        {
            var result = _serviceRepository.Query(request).ToList();
            return Json(result);
        }

        [HttpPost]
        public IActionResult QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var result = _serviceRepository.QueryPaged(reqMsg);
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetServiceList([FromQuery]QueryByPageRequest model)
        {
            var result = _serviceRepository.GetList(model);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SaveService(MsService model)
        {
            if (model.Id == 0)
            {
                _serviceRepository.Insert(model);
            }
            else
            {
                _serviceRepository.DyUpdate(new
                {
                    model.Id,
                    model.Port,
                    model.Ip,
                    model.Name,
                    model.Status,
                    model.App,
                    model.Remark,
                    UpdateTime = DateTime.Now
                });
            }
            return Json();
        }

        [HttpPost]
        public IActionResult DeleteService(BaseModel model)
        {
            return Json(_serviceRepository.Delete(model));
        }
    }
}