using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Dispatch.Infrastructure
{
    public class PipelineActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(
            HttpControllerContext controllerContext
        )
        {
            HttpActionDescriptor action = base.SelectAction(controllerContext);

            IEnumerable<FilterInfo> filters = action.GetFilterPipeline();

            foreach (FilterInfo filter in filters)
            {
                Debug.WriteLine("Scope {0} Type: {1}", filter.Scope, filter.Instance.GetType().Name);
            }

            return action;
        }
    }
}