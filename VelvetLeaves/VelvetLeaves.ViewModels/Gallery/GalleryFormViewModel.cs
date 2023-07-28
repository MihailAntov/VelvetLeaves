

using Microsoft.AspNetCore.Http;

namespace VelvetLeaves.ViewModels.Gallery
{
    public class GalleryFormViewModel
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IFormFile Image { get; set; } = null!;

        public string? ImageId { get; set; }
    }
}
