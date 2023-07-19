using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Service.Models
{
	public class ProductsFilteredAndPagedServiceModel
	{
		public IEnumerable<ProductViewModel> Products { get; set; } = new HashSet<ProductViewModel>();
		public int TotalProductCount { get; set; }
	}
}