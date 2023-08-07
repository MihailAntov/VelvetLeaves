

using Microsoft.AspNetCore.Http;
using VelvetLeaves.Common.Validation;
using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.ViewModels.Subcategory
{
    public class SubcategoryFormViewModel
    {
        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        [ImageInput]
        public IFormFile Image { get; set; } = null!;

        public IEnumerable<CategorySelectViewModel> CategoryOptions { get; set; } = new HashSet<CategorySelectViewModel>();
    }
}
