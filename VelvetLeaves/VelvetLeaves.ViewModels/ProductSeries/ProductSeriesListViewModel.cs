

using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.ViewModels.ProductSeries
{
    public class ProductSeriesListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Anchor { get; set; } = null!;

        public IEnumerable<ProductListViewModel> Products { get; set; } = new HashSet<ProductListViewModel>();
    }
}
