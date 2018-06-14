using System.ComponentModel.DataAnnotations;
using System.Web.Http;

namespace ExampleApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        [HttpBindRequired]
        [Range(1, 2000)]
        public decimal Price { get; set; }

        [HttpBindNever]
        public bool IncludeInSale { get; set; }
    }
}