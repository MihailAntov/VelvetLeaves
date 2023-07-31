

namespace VelvetLeaves.ViewModels.Order
{
    public class ShoppingCartItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public string ImageId { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
