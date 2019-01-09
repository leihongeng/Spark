using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace Spark.Config.Api.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        public ActionResult Index()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string version = assembly.FullName.Split(',')[1];

            string fullversion = version.Split('=')[1];

            int major = int.Parse(fullversion.Split('.')[0]);
            int minor = int.Parse(fullversion.Split('.')[1]);
            int build = int.Parse(fullversion.Split('.')[2]);
            int revision = int.Parse(fullversion.Split('.')[3]);

            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(build).AddSeconds(revision * 2);
            string fulldate = buildDate.ToLocalTime().ToString(CultureInfo.InvariantCulture);
            version = string.Format("{0}.{1}.{2}.{3}", major, minor, build, revision);
            version += "</br>" + _env.EnvironmentName;
            return View((object)version);
        }
    }
}