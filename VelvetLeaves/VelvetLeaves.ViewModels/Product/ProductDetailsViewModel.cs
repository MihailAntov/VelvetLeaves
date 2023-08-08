using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.ViewModels.Product
{
    public class ProductDetailsViewModel
    {

        public string Name { get; set; } = null!;
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public bool IsAvailable { get; set; }   
        public IEnumerable<string> Images { get; set; } = new HashSet<string>();
        
        public IEnumerable<ProductListViewModel> ProductSeries { get; set; } = new HashSet<ProductListViewModel>();

        public IEnumerable<MaterialListViewModel> Materials { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> Tags { get; set; } = new HashSet<TagListViewModel>();

    }
}
