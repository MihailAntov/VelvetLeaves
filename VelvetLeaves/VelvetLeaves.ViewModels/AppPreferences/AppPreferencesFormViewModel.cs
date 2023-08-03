

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.ViewModels.AppPreferences
{
    public class AppPreferencesFormViewModel
    {
        [Required]
        public string RootNavigationName { get; set; } = null!;

        [Required]
        public string Currency { get; set; } = null!;

        

        public string ImageId { get; set; }

        public IFormFile? Image { get; set; }

        [Required]
        public string FavoriteIcon { get; set; }
        [Required]
        public string FavoriteColor { get; set; }

    }
}
