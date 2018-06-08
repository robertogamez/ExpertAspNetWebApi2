using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Infrastructure
{
    public class HeaderValueProviderFatory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext context)
        {
            if (context.Request.Method == HttpMethod.Post)
            {
                return new HeaderVaueProvider(new HeadersMap(context.Request.Headers));
            }
            else
            {
                return null;
            }
        }
    }
}