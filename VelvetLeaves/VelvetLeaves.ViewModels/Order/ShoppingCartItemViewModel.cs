

using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.ViewModels.Order
{
    public class ShoppingCartItemViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string ImageId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
