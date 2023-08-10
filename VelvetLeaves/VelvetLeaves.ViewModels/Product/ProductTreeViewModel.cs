


using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.ViewModels.Product
{
    public class ProductTreeViewModel
    {
        public IEnumerable<CategoryListViewModel> Products { get; set; } = new HashSet<CategoryListViewModel>();
       
        public int? CategoryId { get; set; }
        
        public int? SubcategoryId { get; set; }
        
        public int? ProductSeriesId { get; set; }

        public IEnumerable<ColorSelectViewModel> Colors { get; set; } = new HashSet<ColorSelectViewModel>();
        public IEnumerable<MaterialListViewModel> Materials { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> Tags { get; set; } = new HashSet<TagListViewModel>();
        
    }
}
