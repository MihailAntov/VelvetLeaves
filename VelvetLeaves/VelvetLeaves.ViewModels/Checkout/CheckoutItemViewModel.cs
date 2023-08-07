using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.ViewModels.Checkout
{
	public class CheckoutItemViewModel
	{
        [Required]
		public int Id { get; set; }

		[Required]
		public int Quantity { get; set; }
	}
}
