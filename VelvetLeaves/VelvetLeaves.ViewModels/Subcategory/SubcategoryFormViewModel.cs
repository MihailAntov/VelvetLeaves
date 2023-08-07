

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using VelvetLeaves.ViewModels.Category;
using static VelvetLeaves.Common.ValidationConstants.Category;

namespace VelvetLeaves.ViewModels.Subcategory
{
    public class SubcategoryFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Name { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [ImageInput]
        public IFormFile Image { get; set; } = null!;

        public IEnumerable<CategorySelectViewModel> CategoryOptions { get; set; } = new HashSet<CategorySelectViewModel>();
    }
}
