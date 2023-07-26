

using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.ProductSeries;
using VelvetLeaves.ViewModels.Subcategory;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.ViewModels.Product
{
    public class ProductFormViewModel
    {
        public string Name { get; set; }
        public string DefaultName { get; set; }

        public decimal Price { get; set; }
        public decimal DefaultPrice { get; set; }

        public string Description { get; set; }
        public string DefaultDescription { get; set; } = null!;

        public  int ProductSeriesId { get; set; }
        public int SubcategoryId { get; set; }
        public int CategoryId { get; set; }


        public IEnumerable<ColorSelectViewModel> DefaultColors { get; set; } = new HashSet<ColorSelectViewModel>();
        public IEnumerable<MaterialListViewModel> DefaultSubcategories { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> DefaultTags { get; set; } = new HashSet<TagListViewModel>();



        public IEnumerable<ColorSelectViewModel> ColorOptions { get; set; } = new HashSet<ColorSelectViewModel>();
        public IEnumerable<CategorySelectViewModel> CategoryOptions { get; set; } = new HashSet<CategorySelectViewModel>();
        public IEnumerable<SubcategorySelectViewModel> SubcategoryOptions { get; set; } = new HashSet<SubcategorySelectViewModel>();
        public IEnumerable<MaterialListViewModel> MaterialOptions { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> TagOptions { get; set; } = new HashSet<TagListViewModel>();
        public IEnumerable<ProductSeriesSelectViewModel> ProductSeriesOptions { get; set; } = new HashSet<ProductSeriesSelectViewModel>();

    }
}
