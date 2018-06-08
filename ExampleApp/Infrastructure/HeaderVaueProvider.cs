using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Infrastructure
{
    public class HeaderVaueProvider : IValueProvider
    {
        private HeadersMap headers;

        public HeaderVaueProvider(HeadersMap map)
        {
            headers = map;
        }

        public bool ContainsPrefix(string prefix)
        {
            return false;
        }

        public ValueProviderResult GetValue(string key)
        {
            string value = headers[key];

            return value == null ? null : new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
        }
    }
}