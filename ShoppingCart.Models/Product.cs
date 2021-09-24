namespace ShoppingCart.Models
{
    public class Product : BaseDbModel
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
