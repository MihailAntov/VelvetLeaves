

namespace VelvetLeaves.Service.Models.ShoppingCart
{
    public class ProductForCartDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageId { get; set; } = null!;
        public bool IsAvailable { get; set; }
    }
}
