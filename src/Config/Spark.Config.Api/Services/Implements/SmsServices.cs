using System;
using AutoMapper;
using Spark.Config.Api.AppCode;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Sms;
using Spark.Config.Api.Entity;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core;
using Spark.Core.Exceptions;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Implements
{
    public class SmsServices : ISmsServices
    {
        private readonly ISmsRepository _smsRepository;
        private readonly IAppRepository _appRepository;
        private readonly IUser _user;
        private readonly IPower _power;
        private readonly IMapper _mapper;

        public SmsServices(ISmsRepository smsRepository
            , IAppRepository appRepository
            , IUser user
            , IPower power
            , IMapper mapper)
        {
            _smsRepository = smsRepository;
            _appRepository = appRepository;
            _user = user;
            _power = power;
            _mapper = mapper;
        }

        public QueryPageResponse<SmsTempResponse> LoadTempList(SmsTempSearchRequest request)
        {
            request.IsAdmin = _power.IsAdmin;
            request.UserId = _user.Id;
            return _smsRepository.GetTempList(request);
        }

        public QueryPageResponse<SmsRecordResponse> LoadRecordList(SmsRecordSearchRequest request)
        {
            request.IsAdmin = _power.IsAdmin;
            request.UserId = _user.Id;
            return _smsRepository.GetRecordList(request);
        }

        public void SaveTemp(SmsTempRequest request)
        {
            var app = _appRepository.GetById(request.AppId);
            if (app == null)
                throw new SparkException("项目Id有误！");

            if (request.Id == 0)
            {
                var smsTemp = _mapper.Map<SmsTemp>(request);
                smsTemp.AppCode = app.Code;
                _smsRepository.InsertTemp(smsTemp);
            }
            else
            {
                _smsRepository.UpdateTemp(
                    new
                    {
                        request.Id,
                        request.TempCode,
                        request.Name,
                        request.Content,
                        UpdateTime = DateTime.Now
                    });
            }
        }

        public void RemoveTemp(BaseRequest request)
        {
            _smsRepository.UpdateTemp(
                new
                {
                    request.Id,
                    IsDelete = 1,
                    UpdateTime = DateTime.Now,
                });
        }
    }
}