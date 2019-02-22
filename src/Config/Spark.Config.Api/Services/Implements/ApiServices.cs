using AutoMapper;
using Spark.Config.Api.AppCode;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Service;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Exceptions;
using Spark.Core.Values;
using System;

namespace Spark.Config.Api.Services.Implements
{
    public class ApiServices : IApiServices
    {
        #region Private Fields

        private readonly IServiceRepository _serviceRepository;
        private readonly IAppRepository _appRepository;
        private readonly IPower _power;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Constructor

        public ApiServices(IServiceRepository serviceRepository
            , IAppRepository appRepository
            , IPower power
            , IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _appRepository = appRepository;
            _power = power;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Service Query/Save

        public QueryPageResponse<ApiServiceResponse> LoadList(ApiServiceSearchRequest request)
        {
            request.IsAdmin = _power.IsAdmin;
            request.UserId = _power.UserId;
            return _serviceRepository.GetList(request);
        }

        public void Save(ApiServiceRequest request)
        {
            var app = _appRepository.GetEntity(new { Code = request.AppCode });
            if (app == null)
                throw new SparkException("项目不存在！");

            if (request.Id == 0)
            {
                var service = _mapper.Map<Service>(request);
                service.AppId = app.Id;
                _serviceRepository.Insert(service);
            }
            else
            {
                _serviceRepository.DyUpdate(
                    new
                    {
                        request.Id,
                        AppCode = app.Code,
                        AppId = app.Id,
                        request.Ip,
                        request.Name,
                        request.Remark,
                        request.Port,
                        request.Status,
                        UpdateTime = DateTime.Now
                    });
            }
        }

        public void SetStatus(BaseRequest request)
        {
            var service = _serviceRepository.GetById(request.Id);
            if (service == null)
                throw new SparkException("服务不存在！");

            _serviceRepository.DyUpdate(
                new
                {
                    request.Id,
                    Status = service.Status == 0 ? 1 : 0,
                    UpdateTime = DateTime.Now
                });
        }

        #endregion Service Query/Save
    }
}