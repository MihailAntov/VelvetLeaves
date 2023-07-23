using VelvetLeaves.ViewModels.Subcategory;

namespace VelvetLeaves.ViewModels.Category
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Anchor { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public IEnumerable<SubcategoryListViewModel> Subcategories { get; set; } = new HashSet<SubcategoryListViewModel>();
    }
}
