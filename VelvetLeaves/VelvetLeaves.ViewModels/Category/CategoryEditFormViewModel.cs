

using Microsoft.AspNetCore.Http;

namespace VelvetLeaves.ViewModels.Category
{
	public class CategoryEditFormViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string ImageId { get; set; } = null!;
		public IFormFile? Image { get; set; }
	}
}
