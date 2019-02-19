using AutoMapper;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.User;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Exceptions;
using Spark.Core.Values;
using System;

namespace Spark.Config.Api.Services.Implements
{
    public class UserServices : IUserServices
    {
        #region Private Fields

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Constructor

        public UserServices(IUserRepository userRepository
            , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        #endregion Constructor

        #region User Query/Save

        public QueryPageResponse<UserResponse> LoadList(KeywordQueryPageRequest request)
        {
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
            _userRepository.Insert(_mapper.Map<User>(request));
        }

        private void ModifyUser(UserRequest request)
        {
            _userRepository.DyUpdate(
                new
                {
                    request.Id,
                    request.Mobile,
                    request.Password,
                    UpdateTime = DateTime.Now
                });
        }

        #endregion User Query/Save
    }
}