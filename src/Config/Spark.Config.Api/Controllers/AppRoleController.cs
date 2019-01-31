﻿using Fruit.Entity;
using Fruit.IService;
using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTOs.App;
using Spark.Core.Exceptions;
using System;

namespace Spark.Config.Api.Controllers
{
    /// <summary>
    /// 应用授权
    /// </summary>
    public class AppRoleController : BaseController
    {
        private readonly IAppService _appService;
        private readonly IUserService _userService;
        private readonly IAppRoleService _appRoleService;

        /// <param name="appService"></param>
        /// <param name="userService"></param>
        /// <param name="appRoleService"></param>
        public AppRoleController(IAppService appService, IUserService userService, IAppRoleService appRoleService)
        {
            _appService = appService;
            _userService = userService;
            _appRoleService = appRoleService;
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert(AddAppRoleRequest request)
        {
            if (!_appService.IsExist(new { Id = request.AppId }))
            {
                throw new SparkException("AppId不存在");
            }
            if (!_userService.IsExist(new { Id = request.UserId }))
            {
                throw new SparkException("UserId不存在");
            }

            var appRole = _appRoleService.GetEntity(new { request.AppId, request.UserId });
            if (appRole == null)
            {
                var appRoleEntity = new AppRole()
                {
                    AppId = request.AppId,
                    UserId = request.UserId
                };
                var appRoleId = _appRoleService.Insert(appRoleEntity);

                return Json(appRoleId);
            }

            return Json();
        }

        /// <summary>
        /// 删除授权
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteById([FromBody]long id)
        {
            _appRoleService.DeleteById(id);
            return Json();
        }
    }
}