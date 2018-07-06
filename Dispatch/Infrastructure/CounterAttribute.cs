using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Dispatch.Infrastructure
{
    //public class CounterAttribute : Attribute, IActionFilter
    //{
    //    private static int counter = 0;
    //    private static int limit;

    //    public CounterAttribute(int requestLimit)
    //    {
    //        limit = requestLimit;
    //    }



    //    public bool AllowMultiple
    //    {
    //        get
    //        {
    //            return false;
    //        }
    //    }

    //    public Task<HttpResponseMessage> ExecuteActionFilterAsync(
    //        HttpActionContext actionContext,
    //        CancellationToken cancellationToken,
    //        Func<Task<HttpResponseMessage>> continuation)
    //    {

    //        if (counter < limit)
    //        {
    //            Debug.WriteLine("Request {0} of {1}", counter, limit);
    //            counter++;
    //            return continuation();
    //        }
    //        else
    //        {
    //            HttpResponseMessage response = actionContext.Request
    //                                                .CreateErrorResponse(HttpStatusCode.ServiceUnavailable, "Limit Reached");
    //            return Task.FromResult<HttpResponseMessage>(response);
    //        }

    //    }
    //}

    public class CounterAttribute : ActionFilterAttribute
    {
        private static int counter = 0;
        private static int limit;

        public CounterAttribute(int requestLimit)
        {
            limit = requestLimit;
        }

        public override Task OnActionExecutingAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                if (counter < limit)
                {
                    Debug.WriteLine("Request {0} of {1}", counter, limit);
                    counter++;
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.ServiceUnavailable, "Limit Reached"
                    );
                }
            });
        }
    }
}