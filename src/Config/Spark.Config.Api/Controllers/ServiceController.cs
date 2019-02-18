﻿using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Service;
using Spark.Config.Api.Services.Abstractions;

namespace Spark.Config.Api.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IApiServices _apiServices;

        public ServiceController(IApiServices apiServices)
        {
            _apiServices = apiServices;
        }

        /// <summary>
        /// 分页获取可用服务列表
        /// </summary>
        [HttpGet]
        public IActionResult List([FromQuery] ApiServiceSearchRequest request)
        {
            return Json(_apiServices.LoadList(request));
        }

        /// <summary>
        /// 新增/修改服务详情
        /// </summary>
        [HttpPost]
        public IActionResult Save(ApiServiceRequest request)
        {
            return Json();
        }

        /// <summary>
        /// 设置服务可用状态
        /// </summary>
        [HttpPost]
        public IActionResult SetStatus(BaseRequest request)
        {
            return Json();
        }
    }
}