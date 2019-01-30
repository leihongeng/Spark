using Fruit.Entity;
using Fruit.IService;
using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTOs.App;
using Spark.Core.Exceptions;

namespace Spark.Config.Api.Controllers
{
    /// <summary>
    /// 应用接口
    /// </summary>
    public class AppController : BaseController
    {
        private readonly IAppService _appService;

        public AppController(IAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public IActionResult Insert(AddAppRequest request)
        {
            var app = _appService.GetEntity(new { request.Code });
            if (app != null)
            {
                throw new SparkException("App已存在，请重新输入");
            }

            var appEntity = new App()
            {
                Code = request.Code,
                Name = request.Name,
                Remark = request.Remark
            };
            var appId = _appService.Insert(appEntity);

            return Json(appId);
        }

        #region bak

        //public IMsAppRepository _appRepository { get; }

        //public AppController(IMsAppRepository appRepository)
        //{
        //    _appRepository = appRepository;
        //}

        //[HttpPost]
        //public BaseResponse<IEnumerable<MsApp>> Query()
        //{
        //    var result = _appRepository.Query(null);

        //    return new BaseResponse<IEnumerable<MsApp>>(result);
        //}

        //[HttpPost]
        //public BaseResponse<QueryByPageResponse<MsApp>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        //{
        //    var result = _appRepository.QueryPaged(reqMsg);

        //    return new BaseResponse<QueryByPageResponse<MsApp>>(result);
        //}

        //[HttpGet]
        //public IActionResult GetAppList()
        //{
        //    return Json(_appRepository.Query(new { }));
        //}

        //[HttpPost]
        //public IActionResult SaveApp(MsApp model)
        //{
        //    if (model.Id == 0)
        //    {
        //        _appRepository.Insert(model);
        //    }
        //    else
        //    {
        //        _appRepository.DyUpdate(new
        //        {
        //            model.Id,
        //            model.Name,
        //            model.Remark,
        //            model.Code,
        //            UpdateTime = DateTime.Now
        //        });
        //    }
        //    return Json();
        //}

        //[HttpPost]
        //public IActionResult DeleteApp(BaseModel model)
        //{
        //    return Json(_appRepository.Delete(model));
        //}

        #endregion bak
    }
}