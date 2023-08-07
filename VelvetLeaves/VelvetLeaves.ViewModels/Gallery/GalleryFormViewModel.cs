

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static VelvetLeaves.Common.ValidationConstants.Gallery;
using VelvetLeaves.Common.Validation;

namespace VelvetLeaves.ViewModels.Gallery
{
    public class GalleryFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [ImageInput]
        public IFormFile Image { get; set; } = null!;


        public string? ImageId { get; set; }
    }
}
