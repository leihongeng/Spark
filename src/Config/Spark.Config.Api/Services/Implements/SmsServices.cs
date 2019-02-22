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
        #region Constructor

        private readonly ISmsRepository _smsRepository;
        private readonly IAppRepository _appRepository;
        private readonly IUser _user;
        private readonly IPower _power;
        private readonly IMapper _mapper;

        #endregion Constructor

        #region Constructor

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

        #endregion Constructor

        #region Query

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

        #endregion Query

        #region 短信操作

        public void SaveTemp(SmsTempRequest request)
        {
            var app = _appRepository.GetEntity(new { request.AppCode });
            if (app == null)
                throw new SparkException("项目有误！");

            if (request.Id == 0)
            {
                var smsTemp = _mapper.Map<SmsTemp>(request);
                smsTemp.AppId = app.Id;
                _smsRepository.InsertTemp(smsTemp);
            }
            else
            {
                _smsRepository.UpdateTemp(
                    new
                    {
                        AppId = app.Id,
                        AppCode = app.Code,
                        request.Id,
                        request.TempCode,
                        request.Name,
                        request.Status,
                        request.Content,
                        UpdateTime = DateTime.Now
                    });
            }
        }

        public void SetTempStatus(BaseRequest request)
        {
            var smsTemp = _smsRepository.GetTemp(request.Id);
            if (smsTemp == null)
                throw new SparkException("短信模板不存在！");

            _smsRepository.UpdateTemp(
                new
                {
                    request.Id,
                    Status = smsTemp.Status == 0 ? 1 : 0,
                    UpdateTime = DateTime.Now,
                });
        }

        #endregion 短信操作
    }
}