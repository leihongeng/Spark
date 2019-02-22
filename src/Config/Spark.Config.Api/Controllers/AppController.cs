using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.App;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Values;

namespace Spark.Config.Api.Controllers
{
    public class AppController : BaseController
    {
        private readonly IAppServices _appService;

        public AppController(IAppServices appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// 保存用户勾选的项目集合
        /// </summary>
        [HttpPost]
        public IActionResult Role(AppRoleRequest request)
        {
            _appService.SaveRole(request);
            return Json();
        }

        /// <summary>
        /// 保存应用
        /// </summary>
        [HttpPost]
        public IActionResult Save(AppRequest request)
        {
            _appService.Save(request);
            return Json();
        }

        /// <summary>
        /// 设置App状态(启用/禁用)
        /// </summary>
        [HttpPost]
        public IActionResult SetStatus(BaseRequest request)
        {
            _appService.SetStatus(request);
            return Json();
        }

        /// <summary>
        /// 应用列表
        /// </summary>
        [HttpGet]
        public IActionResult List([FromQuery]KeywordQueryPageRequest request)
        {
            return Json(_appService.LoadList(request));
        }

        /// <summary>
        /// 获取用户项目权限列表
        /// </summary>
        [HttpGet]
        public IActionResult RoleList([FromQuery]KeywordQueryPageRequest request)
        {
            return Json(_appService.LoadRoleList(request));
        }

        /// <summary>
        /// 获取指定用户项目集合
        /// </summary>
        [HttpGet]
        public IActionResult UserAppList(long userId)
        {
            return Json(_appService.LoadUserAppList(userId));
        }
    }
}