using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Service.Models
{
    public class ProductsFilteredAndPagedServiceModel
	{
		public IEnumerable<ProductListViewModel> Products { get; set; } = new HashSet<ProductListViewModel>();
		public int TotalProductCount { get; set; }
	}
}