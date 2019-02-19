using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.User;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Values;

namespace Spark.Config.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 用户新增和保存
        /// </summary>
        [HttpPost]
        public IActionResult Save(UserRequest request)
        {
            _userService.Save(request);
            return Json();
        }

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        [HttpGet]
        public IActionResult List([FromQuery]KeywordQueryPageRequest request)
        {
            return Json(_userService.LoadList(request));
        }

        [HttpPost]
        public IActionResult SetStatus(BaseRequest request)
        {
            _userService.SetStatus(request);
            return Json();
        }
    }
}