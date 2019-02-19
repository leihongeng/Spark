using Spark.Config.Api.DTO;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Exceptions;

namespace Spark.Config.Api.Services.Implements
{
    public class AccountServices : IAccountServices
    {
        private readonly IUserRepository _userRepository;

        public AccountServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(LoginRequest request)
        {
            var user = _userRepository.GetEntity(new { request.UserName });
            if (user.Status == 0)
                throw new SparkException("用户已失效，登录失败！");

            if (user == null)
                throw new SparkException("登录失败！");

            if (user.Password != request.Password)
                throw new SparkException("账号或密码错误！");

            user.Password = string.Empty;
            return user;
        }
    }
}