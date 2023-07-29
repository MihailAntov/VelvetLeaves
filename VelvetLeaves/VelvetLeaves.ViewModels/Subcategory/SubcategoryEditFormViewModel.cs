using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.ViewModels.Subcategory
{
	public class SubcategoryEditFormViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;

		public int CategoryId { get; set; }
		public IFormFile? Image { get; set; }

		public string ImageId { get; set; } = null!;

		public IEnumerable<CategorySelectViewModel> CategoryOptions { get; set; } = new HashSet<CategorySelectViewModel>();
	}
}
