using Fruit.Repository;
using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Core;
using Spark.Core.Exceptions;

namespace Spark.Config.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Login([FromServices] IJwtHandler jwtHandler, LoginModel model)
        {
            var user = _userRepository.GetEntity(new { model.UserName });
            if (user == null)
                throw new SparkException("登录失败！");

            if (user.Password != model.Password)
                throw new SparkException("账号或密码错误！");

            var token = jwtHandler.Create(user.Id);

            var data = new
            {
                User = new { user.Id, user.Mobile, user.UserName },
                Token = token
            };
            return Json(data);
        }

        [HttpGet]
        public IActionResult Test([FromServices]IUser user)
        {
            var id = user.Id;
            return Json();
        }
    }
}