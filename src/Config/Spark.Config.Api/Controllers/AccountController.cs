using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core;

namespace Spark.Config.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountServices _accountService;

        public AccountController(IAccountServices accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Login([FromServices] IJwtHandler jwtHandler, LoginRequest request)
        {
            var user = _accountService.Login(request);
            var token = jwtHandler.Create(user.Id);
            var data =
                new
                {
                    User = new { user.Id, user.Mobile, user.UserName },
                    Token = token
                };
            return Json(data);
        }
    }
}