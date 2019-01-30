using Fruit.Entity;
using Fruit.IService;
using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTOs.User;
using Spark.Core.Exceptions;
using System;

namespace Spark.Config.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert(AddUserRequest request)
        {
            var user = _userService.GetEntity(new { request.UserName });
            if (user != null)
            {
                throw new SparkException("账号已存在，请重新输入");
            }

            var userEntity = new User()
            {
                Mobile = request.Mobile,
                UserName = request.UserName,
                Password = request.Password
            };
            var userId = _userService.Insert(userEntity);

            return Json(userId);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(UpdateUserRequest request)
        {
            var user = _userService.GetEntity(new { request.Id });
            if (user != null)
            {
                user.Mobile = request.Mobile;
                user.UserName = request.UserName;
                user.Password = request.Password;
                user.UpdateTime = DateTime.Now;

                return Json(_userService.Update(user));
            }
            else
            {
                throw new SparkException("未找到要修改的数据");
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteById([FromBody]long id)
        {
            _userService.DeleteById(id);
            return Json();
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList([FromQuery]QueryUserRequest request)
        {
            var data = _userService.QueryPaged(request);
            return Json(data);
        }
    }
}