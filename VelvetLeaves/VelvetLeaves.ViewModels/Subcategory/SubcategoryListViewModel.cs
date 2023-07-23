

using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.ViewModels.Subcategory
{
    public class SubcategoryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Anchor { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public IEnumerable<ProductSeriesListViewModel> ProductSeries { get; set; } = null!;
    }
}
