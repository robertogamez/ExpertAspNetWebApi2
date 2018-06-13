namespace ExampleApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IncludeInSale { get; set; }
    }
}