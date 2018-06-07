using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleApp.Controllers.WebApi
{
    public class BindingsController : ApiController
    {
        private IRepository repo;

        public BindingsController(IRepository repoArg)
        {
            repo = repoArg;
        }

        [HttpGet]
        [HttpPost]
        //public int SumNumbers([FromUri]Numbers calc, [FromUri]Operation op)
        //{
        //    int result = op.Add ? calc.First + calc.Second : calc.First - calc.Second;

        //    return op.Double ? result * 2 : result;
        //}
        public int SumNumbers(Numbers calc)
        {
            return calc.First + calc.Second;
        }
    }
} 