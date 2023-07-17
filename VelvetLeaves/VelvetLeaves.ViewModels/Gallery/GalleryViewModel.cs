
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.ViewModels.Gallery
{
    public class GalleryViewModel
    {
        public ICollection<ProductViewModel> Products { get; set; } = new HashSet<ProductViewModel>();
    }
}
