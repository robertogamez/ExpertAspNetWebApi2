using ExampleApp.Infrastructure;
using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

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
        //public string SumNumbers(Numbers calc, [ValueProvider(typeof(HeaderValueProviderFatory))]string accept)
        //{
        //    return string.Format("{0} (Accept: {1})", calc.First + calc.Second, accept);
        //}

        public string SumNumbers([ModelBinder]int[] numbers)
        {
            return numbers.Sum().ToString();
        }
    }
} 