using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Infrastructure
{
    //public class FromHeaderAttribute : ModelBinderAttribute
    //{
    //    public override IEnumerable<ValueProviderFactory> GetValueProviderFactories(
    //        HttpConfiguration configuration)
    //    {
    //        return new ValueProviderFactory[] { new HeaderValueProviderFatory() };
    //    }
    //}
    public class FromHeaderAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new HeaderValueParameterBinding(parameter);
        }
    }
}