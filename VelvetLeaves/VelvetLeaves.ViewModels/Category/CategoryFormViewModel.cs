
using Microsoft.AspNetCore.Http;

namespace VelvetLeaves.ViewModels.Category
{
    public class CategoryFormViewModel
    {
        public string Name { get; set; } = null!;

        
        public IFormFile Image { get; set; } = null!;
    }
}
