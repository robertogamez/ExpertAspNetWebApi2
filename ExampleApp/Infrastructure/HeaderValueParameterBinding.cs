using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Infrastructure
{
    public class HeaderValueParameterBinding : HttpParameterBinding
    {
        private HeaderValueProviderFatory factory;

        public HeaderValueParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
            factory = new HeaderValueProviderFatory();
        }

        public override Task ExecuteBindingAsync(
            ModelMetadataProvider metadataProvider, 
            HttpActionContext actionContext, 
            CancellationToken cancellationToken)
        {
            IValueProvider valueProvider = factory.GetValueProvider(actionContext);
            if(valueProvider != null)
            {
                ValueProviderResult result
                    = valueProvider.GetValue(Descriptor.ParameterName);

                if(result != null)
                {
                    SetValue(actionContext, result.RawValue);
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}