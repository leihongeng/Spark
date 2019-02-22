using AutoMapper;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.App;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core;
using Spark.Core.Exceptions;
using Spark.Core.Values;
using System;
using System.Collections.Generic;

namespace Spark.Config.Api.Services.Implements
{
    public class AppServices : IAppServices
    {
        #region Private Fields

        private readonly IAppRepository _appRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUser _user;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Constructor

        public AppServices(IAppRepository appRepository
            , IUserRepository userRepository
            , IUser user
            , IMapper mapper)
        {
            _appRepository = appRepository;
            _userRepository = userRepository;
            _user = user;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Query

        public QueryPageResponse<AppResponse> LoadList(KeywordQueryPageRequest request)
        {
            return _appRepository.GetList(request);
        }

        public List<AppResponse> LoadUserAppList(long userId = 0, int isAdmin = 0)
        {
            if (userId == 0)
                userId = _user.Id;

            return _appRepository.GetUserAppList(userId, isAdmin);
        }

        public QueryPageResponse<AppRoleResponse> LoadRoleList(KeywordQueryPageRequest request)
        {
            return _appRepository.GetRoleList(request);
        }

        #endregion Query

        #region App 保存，权限查看

        public void SaveRole(AppRoleRequest request)
        {
            if (_userRepository.GetById(request.UserId) == null)
                throw new SparkException("用户不存在！");

            _appRepository.DeleteRole(new { request.UserId });

            List<AppRole> roleList = new List<AppRole>();

            foreach (var item in request.AppIds)
            {
                roleList.Add(
                    new AppRole
                    {
                        AppId = item,
                        UserId = request.UserId
                    });
            }

            roleList.ForEach(item => { _appRepository.InsertRole(item); });
        }

        public void Save(AppRequest request)
        {
            if (request.Id == 0)
            {
                if (_appRepository.IsExist(new { request.Code }))
                    throw new SparkException("项目编码不能重复！");

                _appRepository.Insert(_mapper.Map<App>(request));
            }
            else
            {
                var app = _appRepository.GetById(request.Id);
                if (app == null)
                    throw new SparkException("项目不存在！");

                var count = _appRepository.GetRecord(new { request.Code });
                if (app.Code != request.Code && count >= 1)
                    throw new SparkException("项目编码不能重复！");

                _appRepository.DyUpdate(
                    new
                    {
                        request.Id,
                        request.Name,
                        request.Code,
                        request.Remark,
                        request.Status,
                        UpdateTime = DateTime.Now
                    });
            }
        }

        public void SetStatus(BaseRequest request)
        {
            var app = _appRepository.GetById(request.Id);
            if (app == null)
                throw new SparkException("项目不存在！");

            _appRepository.DyUpdate(
                new
                {
                    request.Id,
                    Status = app.Status == 0 ? 1 : 0,
                    UpdateTime = DateTime.Now
                });
        }

        #endregion App 保存，权限查看
    }
}