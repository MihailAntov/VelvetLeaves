

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;

namespace VelvetLeaves.ViewModels.AppPreferences
{
    public class AppPreferencesFormViewModel
    {
        [Required]
        [SanitizeStringInput]

        public string RootNavigationName { get; set; } = null!;

        [Required]
        [SanitizeStringInput]
        public string Currency { get; set; } = null!;


        [Required]
        public string ImageId { get; set; } = null!;

        [ImageInput]
        public IFormFile? Image { get; set; }

        [Required]
        [SanitizeStringInput]
        public string FavoriteIcon { get; set; } = null!;

        [Required]
        [SanitizeStringInput]
        public string FavoriteColor { get; set; } = null!;

    }
}
