

using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.Subcategory;
using VelvetLeaves.ViewModels.Tag;
using static VelvetLeaves.Common.ValidationConstants.Product;
namespace VelvetLeaves.ViewModels.ProductSeries
{
    public class ProductSeriesFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Nust be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Name { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Nust be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string DefaultName { get; set; } = null!;

        [Required]
        [Range(MinPrice, MaxPrice)]
        public decimal DefaultPrice { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Nust be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string DefaultDescription { get; set; } = null!;

        public IEnumerable<int> DefaultColorIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> DefaultMaterialIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> DefaultTagIds { get; set; } = new HashSet<int>();



        public IEnumerable<ColorSelectViewModel> ColorOptions { get; set; } = new HashSet<ColorSelectViewModel>();
        public IEnumerable<CategorySelectViewModel> CategoryOptions { get; set; } = new HashSet<CategorySelectViewModel>();
        public IEnumerable<SubcategorySelectViewModel> SubcategoryOptions { get; set; } = new HashSet<SubcategorySelectViewModel>();
        public IEnumerable<MaterialListViewModel> MaterialOptions { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> TagOptions { get; set; } = new HashSet<TagListViewModel>();
    }
}
