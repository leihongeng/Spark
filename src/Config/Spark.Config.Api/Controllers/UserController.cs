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

        [HttpPost]
        public IActionResult Save(UserRequest request)
        {
            _userService.Save(request);
            return Json();
        }

        [HttpGet]
        public IActionResult List([FromQuery]KeywordQueryPageRequest request)
        {
            return Json(_userService.LoadList(request));
        }

        [HttpPost]
        public IActionResult Delete(BaseRequest request)
        {
            _userService.Remove(request);
            return Json();
        }
    }
}