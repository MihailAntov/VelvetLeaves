
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.ViewModels.Gallery
{
    public class GalleryViewModel
    {
        public ICollection<ProductListViewModel> Products { get; set; } = new HashSet<ProductListViewModel>();
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
