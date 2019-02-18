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
        private readonly IAppRepository _appRepository;
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public AppServices(IAppRepository appRepository
            , IUser user
            , IMapper mapper)
        {
            _appRepository = appRepository;
            _user = user;
            _mapper = mapper;
        }

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
                        UpdateTime = DateTime.Now
                    });
            }
        }

        public void Remove(BaseRequest request)
        {
            if (request.Id <= 0)
                throw new SparkException("参数异常！");

            _appRepository.DyUpdate(
                new
                {
                    request.Id,
                    IsDelete = 1,
                    UpdateTime = DateTime.Now
                });
        }
    }
}