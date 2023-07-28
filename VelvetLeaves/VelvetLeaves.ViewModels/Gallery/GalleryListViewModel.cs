

using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.ViewModels.Gallery
{
    public class GalleryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageId { get; set; } = null!;
        public IEnumerable<ProductListViewModel> Products { get; set; } = new HashSet<ProductListViewModel>();
    }
}
