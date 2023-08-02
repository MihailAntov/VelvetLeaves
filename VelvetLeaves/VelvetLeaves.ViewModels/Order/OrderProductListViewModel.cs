

namespace VelvetLeaves.ViewModels.Order
{
	public class OrderProductListViewModel
	{
		public string ImageId { get; set; } = null!;
		public string Name { get; set; } = null!;
		public int Quantity { get; set; }

		public int ProductId { get; set; }

		public decimal Price { get; set;  }

	}
}
