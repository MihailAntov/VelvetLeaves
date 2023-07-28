

using Microsoft.AspNetCore.Http;

namespace VelvetLeaves.ViewModels.Gallery
{
    public class GalleryEditFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IFormFile? Image { get; set; } 
        public string ImageId { get; set; } = null!;
    }
}
