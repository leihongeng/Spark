using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.Sms;
using Spark.Config.Api.Services.Abstractions;

namespace Spark.Config.Api.Controllers
{
    public class SmsController : BaseController
    {
        private readonly ISmsServices _smsService;

        public SmsController(ISmsServices smsService)
        {
            _smsService = smsService;
        }

        /// <summary>
        /// 获取短信模板记录
        /// </summary>
        [HttpGet]
        public IActionResult TempList([FromQuery]SmsTempSearchRequest request)
        {
            return Json(_smsService.LoadTempList(request));
        }

        /// <summary>
        /// 获取短信发送记录
        /// </summary>
        [HttpGet]
        public IActionResult RecordList([FromQuery]SmsRecordSearchRequest request)
        {
            return Json(_smsService.LoadRecordList(request));
        }

        /// <summary>
        /// 保存短信模板
        /// </summary>
        [HttpPost]
        public IActionResult SaveTemp(SmsTempRequest request)
        {
            _smsService.SaveTemp(request);
            return Json();
        }

        /// <summary>
        /// 设置短信模板状态(启用/禁用)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetTempStatus(BaseRequest request)
        {
            _smsService.SetTempStatus(request);
            return Json();
        }
    }
}