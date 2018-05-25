using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleApp.Infrastructure
{
    public class ProductFormatter : MediaTypeFormatter
    {
        public ProductFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x.product"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Product) || type == typeof(IEnumerable<Product>);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext, CancellationToken cancellationToken)
        {
            List<string> productStrings = new List<string>();
            IEnumerable<Product> products = value is Product ? new Product[] { (Product)value } : (IEnumerable<Product>)value;

            foreach (Product product in products)
            {
                productStrings.Add(string.Format("{0},{1},{2}", product.ProductID, product.Name, product.Price));
            }

            StreamWriter writer = new StreamWriter(writeStream);
            await writer.WriteAsync(string.Join(",", productStrings));

            writer.Flush();
        }
    }
}