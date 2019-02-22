using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Config;
using Spark.Config.Api.Services.Abstractions;

namespace Spark.Config.Api.Controllers
{
    public class ConfigController : BaseController
    {
        private readonly IConfigServices _configServices;

        public ConfigController(IConfigServices configServices)
        {
            _configServices = configServices;
        }

        /// <summary>
        /// 分页获取配置列表
        /// </summary>
        [HttpGet]
        public IActionResult List([FromQuery]ConfigSearchRequest request)
        {
            return Json(_configServices.LoadList(request));
        }

        /// <summary>
        /// 新增/保存配置详情
        /// </summary>
        [HttpPost]
        public IActionResult Save(ConfigRequest request)
        {
            _configServices.Save(request);
            return Json();
        }

        /// <summary>
        /// 设置配置文件状态
        /// </summary>
        [HttpPost]
        public IActionResult SetStatus(BaseRequest request)
        {
            _configServices.SetStatus(request);
            return Json();
        }

        /// <summary>
        ///获取最新可用的配置文件
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Latest([FromQuery] ConfigLatestRequest request)
        {
            return Json(_configServices.LoadLatestConfig(request));
        }
    }
}