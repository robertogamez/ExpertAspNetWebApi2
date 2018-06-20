using Dispatch.Models;
using System.Net;
using System.Web.Http;

namespace Dispatch.Controllers
{
    public class ProductsService : ApiController
    {
        public IHttpActionResult Get()
        {
            return StatusCode(HttpStatusCode.ServiceUnavailable);
        }
        public IHttpActionResult Get(int id)
        {
            return StatusCode(HttpStatusCode.ServiceUnavailable);
        }
        public IHttpActionResult Post(Product product)
        {
            return StatusCode(HttpStatusCode.ServiceUnavailable);
        }
    }
}