using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetLeaves.Common.Validation;
using VelvetLeaves.ViewModels.Category;
using static VelvetLeaves.Common.ValidationConstants.Category;

namespace VelvetLeaves.ViewModels.Subcategory
{
	public class SubcategoryEditFormViewModel
	{
        [Required]
		public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
		[DataType(DataType.Text)]
		[SanitizeStringInput]
		public string Name { get; set; } = null!;

		public int CategoryId { get; set; }

		[ImageInput]
		public IFormFile? Image { get; set; }

		public string ImageId { get; set; } = null!;

		public IEnumerable<CategorySelectViewModel> CategoryOptions { get; set; } = new HashSet<CategorySelectViewModel>();
	}
}
