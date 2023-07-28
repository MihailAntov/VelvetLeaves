

using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.ViewModels.Subcategory
{
    public class SubcategoryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Anchor { get; set; } = null!;

        public string ImageId { get; set; } = null!;
        public IEnumerable<ProductSeriesListViewModel> ProductSeries { get; set; } = null!;
        public IEnumerable<ProductListViewModel> Products { get; set; } = new HashSet<ProductListViewModel>();
    }
}
