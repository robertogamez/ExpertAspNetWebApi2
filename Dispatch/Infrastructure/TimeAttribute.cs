using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Dispatch.Infrastructure
{
    public class TimeAttribute : Attribute, IActionFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(
            HttpActionContext actionContext, CancellationToken cancellationToken, 
            Func<Task<HttpResponseMessage>> continuation)
        {
            Stopwatch sw = Stopwatch.StartNew();

            HttpResponseMessage result = await continuation();

            long elapsedTicks = sw.ElapsedTicks;

            result.Headers.Add("Elapsed-Time", elapsedTicks.ToString());
            Debug.WriteLine("Elapsed time: {0} ticks, {1} {2}", elapsedTicks, actionContext.Request.Method, actionContext.Request.RequestUri);
            return result;
        }
    }
}