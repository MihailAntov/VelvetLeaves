
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static VelvetLeaves.Common.ValidationConstants.Category;
namespace VelvetLeaves.ViewModels.Category
{
    public class CategoryFormViewModel
    {
		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; } = null!;
    }
}
