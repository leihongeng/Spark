using AutoMapper;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.User;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Exceptions;
using Spark.Core.Values;
using System;
using Spark.Config.Api.AppCode;

namespace Spark.Config.Api.Services.Implements
{
    public class UserServices : IUserServices
    {
        #region Private Fields

        private readonly IUserRepository _userRepository;
        private readonly IPower _power;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Constructor

        public UserServices(IUserRepository userRepository
            , IPower power
            , IMapper mapper)
        {
            _userRepository = userRepository;
            _power = power;
            _mapper = mapper;
        }

        #endregion Constructor

        #region User Query/Save

        public QueryPageResponse<UserResponse> LoadList(KeywordQueryPageRequest request)
        {
            if (_power.IsAdmin == 0)
            {
                return default(QueryPageResponse<UserResponse>);
            }
            return _userRepository.GetList(request);
        }

        public void Save(UserRequest request)
        {
            if (request.Id == 0)
                AddUser(request);
            else
                ModifyUser(request);
        }

        public void SetStatus(BaseRequest request)
        {
            var user = _userRepository.GetById(request.Id);
            if (user == null)
                throw new SparkException("用户不存在！");

            _userRepository.DyUpdate(
                new
                {
                    request.Id,
                    Status = user.Status == 0 ? 1 : 0,
                    UpdateTime = DateTime.Now
                });
        }

        private void AddUser(UserRequest request)
        {
            if (_userRepository.IsExist(new { request.UserName }))
                throw new SparkException("用户名重复！");

            if (_userRepository.IsExist(new { request.Mobile }))
                throw new SparkException("手机号码重复！");

            _userRepository.Insert(_mapper.Map<User>(request));
        }

        private void ModifyUser(UserRequest request)
        {
            var user = _userRepository.GetById(request.Id);
            if (user == null)
                throw new SparkException("用户不存在！");

            if (user.UserName != request.UserName && _userRepository.IsExist(new { request.UserName }))
                throw new SparkException("用户名重复！");

            if (user.Mobile != request.Mobile && _userRepository.IsExist(new { request.Mobile }))
                throw new SparkException("手机号码重复！");

            _userRepository.DyUpdate(
                new
                {
                    request.Id,
                    request.Mobile,
                    request.Password,
                    request.UserName,
                    request.Status,
                    UpdateTime = DateTime.Now
                });
        }

        #endregion User Query/Save
    }
}