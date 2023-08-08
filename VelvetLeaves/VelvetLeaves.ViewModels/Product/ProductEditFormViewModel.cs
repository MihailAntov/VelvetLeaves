using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ProductEditFormViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [SanitizeStringInput]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Description { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SubcategoryId { get; set; }

        [Required]
        public int ProductSeriesId { get; set; }

        //[FileExtensions(ErrorMessage = "Invalid file.")]
        [ImageInput]
        public IEnumerable<IFormFile>? Images { get; set; } 
        public IList<string>? ImageIds { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public IEnumerable<string>? StartingImageIds { get; set; } = new HashSet<string>();
        public IEnumerable<string>? KeptImageIds { get; set; } = new HashSet<string>();
        public IEnumerable<int> ColorIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> MaterialIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> TagIds { get; set; } = new HashSet<int>();

        public IEnumerable<ColorSelectViewModel> ColorOptions { get; set; } = new HashSet<ColorSelectViewModel>();

        public IEnumerable<MaterialListViewModel> MaterialOptions { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> TagOptions { get; set; } = new HashSet<TagListViewModel>();

    }
}
