

namespace VelvetLeaves.ViewModels.Order
{
	public class OrderProductListViewModel
	{
		public string ImageId { get; set; } = null!;
		public string Name { get; set; } = null!;
		public int Quantity { get; set; }

		public int ProductId { get; set; }

		public decimal Price { get; set;  }

		public int Id { get; set; }
		public int CategoryId { get; set; }
		public int SubcategoryId { get; set; }
		public int ProductSeriesId { get; set; }

		public bool Removed { get; set; }

	}
}
