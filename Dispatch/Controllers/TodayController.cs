using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dispatch.Controllers
{
    [RoutePrefix("api/today")]
    public class TodayController : ApiController
    {
        //[HttpGet]
        //[Route("dayofweek")]
        //public string DayOfWeek()
        //{
        //    return DateTime.Now.ToString();
        //}

        [HttpGet]
        [Route("dayofweek/{day:int=-1}")]
        public string DayNumber(int day)
        {
            if (day != -1)
            {
                return Enum.GetValues(typeof(DayOfWeek)).GetValue(day).ToString();
            }
            else
            {
                return DateTime.Now.ToString("dddd");
            }
        }

        [HttpGet]
        [Route("~/getdaynumber")]
        public string DayOfWeek(int day)
        {
            return Enum.GetValues(typeof(DayOfWeek)).GetValue(day).ToString();
        }
    }
}
