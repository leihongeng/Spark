using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult TempList([FromQuery]SmsTempSearchRequest request)
        {
            return Json(_smsService.LoadTempList(request));
        }

        [HttpGet]
        public IActionResult RecordList([FromQuery]SmsRecordSearchRequest request)
        {
            return Json(_smsService.LoadRecordList(request));
        }

        [HttpPost]
        public IActionResult SaveTemp(SmsTempRequest request)
        {
            _smsService.SaveTemp(request);
            return Json();
        }
    }
}