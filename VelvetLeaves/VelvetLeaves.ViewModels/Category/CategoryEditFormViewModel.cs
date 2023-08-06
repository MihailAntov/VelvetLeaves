

using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static VelvetLeaves.Common.ValidationConstants.Category;

namespace VelvetLeaves.ViewModels.Category
{
	public class CategoryEditFormViewModel
	{
        [Required]
		public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength =NameMinLength, ErrorMessage ="Name should be between {1} and {0} symbols.")]
		public string Name { get; set; } = null!;

        [Required]
		public string ImageId { get; set; } = null!;

        
		public IFormFile? Image { get; set; }
	}
}
