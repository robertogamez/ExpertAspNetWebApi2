using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleApp.Controllers.WebApi
{
    public class FormatsController : ApiController
    {
        //public object GetData()
        //{
        //    return new
        //    {
        //        Time = DateTime.Now,
        //        Text = "Joe <b>Smith</b>",
        //        Count = 0
        //    };
        //}

        public DataObject GetDataXml()
        {
            return new DataObject
            {
                Time = DateTime.Now,
                Text = "Joe <b>Smith</b>",
                Count = 0
            };
        }
    }

    public class DataObject
    {
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public int Count { get; set; }
    }
}