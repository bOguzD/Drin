namespace Drin.Core
{
    public class ProductFeature 
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public string Colour { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
