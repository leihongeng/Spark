using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core;
using System.Collections.Generic;
using System.Security.Claims;

namespace Spark.Config.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IAccountServices _accountService;
        private readonly IAppServices _appServices;

        public AccountController(IAccountServices accountService
            , IAppServices appServices)
        {
            _accountService = accountService;
            _appServices = appServices;
        }

        [HttpPost]
        public IActionResult Login([FromServices] IJwtHandler jwtHandler, LoginRequest request)
        {
            var user = _accountService.Login(request);
            var token = jwtHandler.Create(user.Id, new List<Claim> { new Claim("IsAdmin", user.IsAdmin.ToString()) });

            var appList = _appServices.LoadUserAppList(user.Id, user.IsAdmin);

            var data =
                new
                {
                    User = new { user.Id, user.Mobile, user.UserName, user.IsAdmin },
                    App = appList,
                    Token = token
                };
            return Json(data);
        }
    }
}