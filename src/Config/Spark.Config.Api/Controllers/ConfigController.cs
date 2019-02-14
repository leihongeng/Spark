using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Values;

namespace Spark.Config.Api.Controllers
{
    public class ConfigController : BaseController
    {
        private readonly IConfigServices _configServices;

        public ConfigController(IConfigServices configServices)
        {
            _configServices = configServices;
        }

        [HttpGet]
        public IActionResult List([FromQuery]KeywordQueryPageRequest request)
        {
            return Json(_configServices.LoadList(request));
        }
    }
}