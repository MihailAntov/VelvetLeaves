

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using static VelvetLeaves.Common.ValidationConstants.Gallery;

namespace VelvetLeaves.ViewModels.Gallery
{
    public class GalleryEditFormViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Description { get; set; } = null!;

        [ImageInput]
        public IFormFile? Image { get; set; } 
        public string ImageId { get; set; } = null!;
    }
}
