

using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.ViewModels.Order
{
    public class CheckoutFormViewModel
    {
        [Required]
        public ShoppingCartViewModel ShoppingCart { get; set; } = null!;

        [Required]
        public AddressFormViewModel Address { get; set; } = null!;
    }
}
