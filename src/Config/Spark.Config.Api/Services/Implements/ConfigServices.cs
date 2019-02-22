using System;
using AutoMapper;
using Spark.Config.Api.AppCode;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Config;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Exceptions;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Implements
{
    public class ConfigServices : IConfigServices
    {
        #region Private Fields

        private readonly IConfigRepository _configRepository;
        private readonly IAppRepository _appRepository;
        private readonly IPower _power;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Constructor

        public ConfigServices(IConfigRepository configRepository
            , IAppRepository appRepository
            , IPower power
            , IMapper mapper)
        {
            _configRepository = configRepository;
            _appRepository = appRepository;
            _power = power;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Query

        public QueryPageResponse<ConfigResponse> LoadList(ConfigSearchRequest request)
        {
            request.IsAdmin = _power.IsAdmin;
            request.UserId = _power.UserId;
            return _configRepository.GetList(request);
        }

        public Entity.Config LoadLatestConfig(ConfigLatestRequest request)
        {
            var config = _configRepository.GetEntity(request);
            if (!request.UpdateTime.HasValue || config.UpdateTime > request.UpdateTime)
            {
                return config;
            }
            return default(Entity.Config);
        }

        #endregion Query

        #region 配置文件修改删除，状态设置

        public void Save(ConfigRequest request)
        {
            var app = _appRepository.GetEntity(new { Code = request.AppCode });
            if (app == null)
                throw new SparkException("项目编码有误！");

            if (request.Id == 0)
            {
                var config = _mapper.Map<Entity.Config>(request);
                config.AppCode = app.Code;
                _configRepository.Insert(config);
            }
            else
            {
                _configRepository.DyUpdate(
                    new
                    {
                        request.Id,
                        request.Content,
                        request.Key,
                        request.Status,
                        request.Remark,
                        request.AppCode,
                        AppId = app.Id,
                        UpdateTime = DateTime.Now,
                    });
            }
        }

        public void SetStatus(BaseRequest request)
        {
            if (request.Id <= 0)
                throw new SparkException("参数Id有误！");

            var config = _configRepository.GetById(request.Id);
            if (config == null)
                throw new SparkException("参数Id有误");

            if (config.Status == 1)
            {
                _configRepository.DyUpdate(
                    new
                    {
                        config.Id,
                        Status = 0,
                        UpdateTime = DateTime.Now
                    });
            }
            else
            {
                _configRepository.DyUpdate(
                    new
                    {
                        config.Id,
                        Status = 1,
                        UpdateTime = DateTime.Now
                    });
            }
        }

        #endregion 配置文件修改删除，状态设置
    }
}