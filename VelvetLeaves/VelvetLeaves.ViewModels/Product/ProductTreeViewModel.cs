


using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.ViewModels.Product
{
    public class ProductTreeViewModel
    {
        public IEnumerable<CategoryListViewModel> Products { get; set; } = new HashSet<CategoryListViewModel>();
       
        public int? CategoryId { get; set; }
        
        public int? SubcategoryId { get; set; }
        
        public int? ProductSeriesId { get; set; }
    }
}
