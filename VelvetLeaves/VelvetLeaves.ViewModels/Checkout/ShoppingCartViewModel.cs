using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.ViewModels.Checkout
{
	public class ShoppingCartViewModel
	{
        [Required]
		public IList<ShoppingCartItemViewModel> Items { get; set; } = new List<ShoppingCartItemViewModel>();
		public decimal Total { get; set; }
		public int TotalItems { get; set; }
		public string Currency { get; set; } = null!;
	}
}
