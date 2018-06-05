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
        public int SumNumbers(Numbers calc)
        {
            return calc.First + calc.Second;
        }
    }
}
