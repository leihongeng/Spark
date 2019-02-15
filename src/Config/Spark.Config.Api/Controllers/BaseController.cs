using Microsoft.AspNetCore.Authorization;
using Spark.Core.Values;
using Microsoft.AspNetCore.Mvc;

namespace Spark.Config.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("monitor/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Json<T>(T obj)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            response.Data = obj;
            response.IsSuccess = true;
            response.Message = "操作成功！";
            return Ok(response);
        }

        protected IActionResult Json()
        {
            BaseResponse response = new BaseResponse();
            response.IsSuccess = true;
            response.Message = "操作成功！";
            return Ok(response);
        }
    }
}