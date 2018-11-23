using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microsoft.Teams.Samples.HelloWorld.Web.Controllers
{
    public class HolidayController : Controller
    {
        [Route("holiday")]
        // GET: Holiday
        public ActionResult Index()
        {
            return View();
        }
    }
}