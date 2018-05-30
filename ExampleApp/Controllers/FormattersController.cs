using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ExampleApp.Controllers
{
    public class FormattersController : Controller
    {
        public ActionResult Index()
        {
            return View(GlobalConfiguration.Configuration.Formatters);
        }
    }
}
