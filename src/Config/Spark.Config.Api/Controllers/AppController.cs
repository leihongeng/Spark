using Microsoft.AspNetCore.Mvc;
using Spark.Config.Api.DTO;
using Spark.Config.Api.DTO.App;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Values;

namespace Spark.Config.Api.Controllers
{
    public class AppController : BaseController
    {
        private readonly IAppServices _appService;

        public AppController(IAppServices appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// �����û���ѡ����Ŀ����
        /// </summary>
        [HttpPost]
        public IActionResult Role(AppRoleRequest request)
        {
            _appService.SaveRole(request);
            return Json();
        }

        /// <summary>
        /// ����Ӧ��
        /// </summary>
        [HttpPost]
        public IActionResult Save(AppRequest request)
        {
            _appService.Save(request);
            return Json();
        }

        /// <summary>
        /// ɾ��Ӧ��
        /// </summary>
        [HttpPost]
        public IActionResult Delete(BaseRequest request)
        {
            _appService.Remove(request);
            return Json();
        }

        /// <summary>
        /// Ӧ���б�
        /// </summary>
        [HttpGet]
        public IActionResult List([FromQuery]KeywordQueryPageRequest request)
        {
            return Json(_appService.LoadList(request));
        }
    }
}