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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository
            , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

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

        public void Remove(BaseRequest request)
        {
            if (request.Id <= 0)
                throw new SparkException("参数值异常！");
            _userRepository.DyUpdate(
                new
                {
                    request.Id,
                    IsDelete = 1,
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
    }
}