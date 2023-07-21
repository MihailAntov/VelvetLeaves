

namespace VelvetLeaves.ViewModels.Product
{
	public class ProductDetailsViewModel
	{

		public string Name { get; set; } = null!;
		public int Id { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;
		public IEnumerable<ProductListViewModel> ProductSeries { get; set; } = new HashSet<ProductListViewModel>();
		 
	}
}
