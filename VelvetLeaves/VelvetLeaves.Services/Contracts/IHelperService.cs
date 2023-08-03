﻿

using VelvetLeaves.ViewModels.AppPreferences;

namespace VelvetLeaves.Services.Contracts
{
    public interface IHelperService
    {
        public Task<string> Currency();
        public Task<string> Background();

        public Task<string> FavoriteColor();
        public Task<string> FavoriteIcon();

        public Task<AppPreferencesFormViewModel> GetCurrentPreferences();

        public Task SetCurrentPreferences (AppPreferencesFormViewModel model);  
    }
}
