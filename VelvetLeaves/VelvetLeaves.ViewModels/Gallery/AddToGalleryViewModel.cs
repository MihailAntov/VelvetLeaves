

using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.ViewModels.Gallery
{
    public class AddToGalleryViewModel
    {
        public int GalleryId { get; set; }
        public string GalleryName { get; set; }
        public IEnumerable<int> ProductIds { get; set; } = new HashSet<int>();
        public IEnumerable<CategoryListViewModel> Categories { get; set; } = new HashSet<CategoryListViewModel>();
    }
}
