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
        private readonly IConfigRepository _configRepository;
        private readonly IAppRepository _appRepository;
        private readonly IPower _power;
        private readonly IMapper _mapper;

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

        public QueryPageResponse<ConfigResponse> LoadList(ConfigSearchRequest request)
        {
            request.IsAdmin = _power.IsAdmin;
            request.UserId = _power.UserId;
            return _configRepository.GetList(request);
        }

        public void Save(ConfigRequest request)
        {
            var app = _appRepository.GetById(request.AppId);
            if (app == null)
                throw new SparkException("项目Id有误！");

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
                        request.AppId,
                        AppCode = app.Code,
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
    }
}