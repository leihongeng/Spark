using System;
using SmartSql.Abstractions;
using Spark.Config.Api.DTO.App;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Spark.Config.Api.DTO;
using Spark.Core.Exceptions;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Implements
{
    public class AppServices : IAppServices
    {
        private readonly IAppRoleRepository _roleRepository;
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;
        private readonly ITransaction _transaction;

        public AppServices(IAppRoleRepository roleRepository
            , IAppRepository appRepository
            , IMapper mapper
            , ITransaction transaction)
        {
            _roleRepository = roleRepository;
            _appRepository = appRepository;
            _mapper = mapper;
            _transaction = transaction;
        }

        public QueryPageResponse<AppResponse> LoadList(KeywordQueryPageRequest request)
        {
            return _appRepository.GetList(request);
        }

        public void SaveRole(AppRoleRequest request)
        {
            //保存用户拥有的项目集合权限
            var list = _roleRepository.Query(new { request.UserId });
            //先删除用户已拥有的项目列表，再重新添加新的
            if (list?.Count() > 0)
            {
                _roleRepository.Delete(new { request.UserId });
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

            roleList.ForEach(item => { _roleRepository.Insert(item); });
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