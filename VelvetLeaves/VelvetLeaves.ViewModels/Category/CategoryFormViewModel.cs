
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using static VelvetLeaves.Common.ValidationConstants.Category;
using static VelvetLeaves.Common.ValidationConstants.Common;
namespace VelvetLeaves.ViewModels.Category
{
    public class CategoryFormViewModel
    {
		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [ImageInput]
        public IFormFile Image { get; set; } = null!;
    }
}
