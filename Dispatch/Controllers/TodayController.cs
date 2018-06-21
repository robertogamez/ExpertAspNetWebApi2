using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dispatch.Controllers
{
    public class TodayController : ApiController
    {
        [HttpGet]
        public string DayOfWeek()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet]
        public int DayNumber()
        {
            return DateTime.Now.Day;
        }
    }
}
