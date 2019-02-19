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
using System.Linq;

namespace Spark.Config.Api.Services.Implements
{
    public class AppServices : IAppServices
    {
        #region Private Fields

        private readonly IAppRepository _appRepository;
        private readonly IUser _user;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Constructor

        public AppServices(IAppRepository appRepository
            , IUser user
            , IMapper mapper)
        {
            _appRepository = appRepository;
            _user = user;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Query

        public QueryPageResponse<AppResponse> LoadList(KeywordQueryPageRequest request)
        {
            return _appRepository.GetList(request);
        }

        public List<AppResponse> LoadUserAppList(long userId = 0)
        {
            if (userId == 0)
                userId = _user.Id;
            return _appRepository.GetUserAppList(userId);
        }

        #endregion Query

        #region App 保存，权限查看

        public void SaveRole(AppRoleRequest request)
        {
            //保存用户拥有的项目集合权限
            var list = _appRepository.QueryRoleList(new { request.UserId });
            //先删除用户已拥有的项目列表，再重新添加新的
            if (list?.Count() > 0)
            {
                _appRepository.DeleteRole(new { request.UserId });
            }

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
                _appRepository.Insert(_mapper.Map<App>(request));
            }
            else
            {
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
                throw new SparkException("App不存在！");

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