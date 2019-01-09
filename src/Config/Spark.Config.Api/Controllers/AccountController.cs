using Spark.Config.Api.DTO;
using Micro.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Spark.Config.Api.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model.Name == "Admin" && model.Pwd == "Gdx123456")
            {
                return Json();
            }

            throw new SparkException("µÇÂ¼Ê§°Ü£¡");
        }
    }
}