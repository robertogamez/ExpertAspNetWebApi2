using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Dispatch.Infrastructure
{
    public class CustomMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage>
            SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post
                && request.Headers.Contains("X-HTTP-Method-Override"))
            {
                HttpMethod requestMethod = new HttpMethod(
                    request.Headers.GetValues("X-HTTP-Method-Override").First()
                );

                if(requestMethod == HttpMethod.Put || requestMethod == HttpMethod.Delete)
                {
                    request.Method = requestMethod;
                }

                return request.CreateResponse(HttpStatusCode.MethodNotAllowed, "Only Put and Delete can be overriden");
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}