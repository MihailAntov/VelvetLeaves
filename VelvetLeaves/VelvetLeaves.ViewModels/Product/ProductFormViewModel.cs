

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.ProductSeries;
using VelvetLeaves.ViewModels.Subcategory;
using VelvetLeaves.ViewModels.Tag;

using static VelvetLeaves.Common.ValidationConstants.Product;
using static VelvetLeaves.Common.ValidationConstants.Common;
using VelvetLeaves.Common.Validation;

namespace VelvetLeaves.ViewModels.Product
{
    public class ProductFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        //[SanitizeStringInput]
        public string Name { get; set; } = null!;


        [Required]
        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        //[SanitizeStringInput]

        public string Description { get; set; } = null!;

        [Required]
        [ImageInput]
        public IEnumerable<IFormFile> Images { get; set; } = null!;

        public IEnumerable<string>? ImageIds { get; set; }

        [Required]
        public  int ProductSeriesId { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        [Required]
        public int CategoryId { get; set; }


        public IEnumerable<int> ColorIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> MaterialIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> TagIds { get; set; } = new HashSet<int>();

        public IEnumerable<int> DefaultColorIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> DefaultMaterialIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> DefaultTagIds { get; set; } = new HashSet<int>();



        public IEnumerable<ColorSelectViewModel> ColorOptions { get; set; } = new HashSet<ColorSelectViewModel>();
        public IEnumerable<CategorySelectViewModel> CategoryOptions { get; set; } = new HashSet<CategorySelectViewModel>();
        public IEnumerable<SubcategorySelectViewModel> SubcategoryOptions { get; set; } = new HashSet<SubcategorySelectViewModel>();
        public IEnumerable<MaterialListViewModel> MaterialOptions { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> TagOptions { get; set; } = new HashSet<TagListViewModel>();
        public IEnumerable<ProductSeriesSelectViewModel> ProductSeriesOptions { get; set; } = new HashSet<ProductSeriesSelectViewModel>();

    }
}
