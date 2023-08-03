

using Microsoft.AspNetCore.Http;

namespace VelvetLeaves.ViewModels.AppPreferences
{
    public class AppPreferencesFormViewModel
    {
        public string RootNavigationName { get; set; }    

        public string Currency { get; set; }

        

        public string? ImageId { get; set; }

        public IFormFile Image { get; set; }

        public string FavoriteIcon { get; set; }
        public string FavoriteColor { get; set; }

    }
}
