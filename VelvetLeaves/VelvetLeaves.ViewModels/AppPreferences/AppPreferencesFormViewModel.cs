

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using static VelvetLeaves.Common.ValidationConstants.AppPreferences;

namespace VelvetLeaves.ViewModels.AppPreferences
{
    public class AppPreferencesFormViewModel
    {
        [Required]
        [StringLength(RootProductsNameMaxLength, MinimumLength = RootProductsNameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
        [SanitizeStringInput]

        public string RootNavigationName { get; set; } = null!;

        [Required]
        [StringLength(CurrencyMaxLength, MinimumLength = CurrencyMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
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
