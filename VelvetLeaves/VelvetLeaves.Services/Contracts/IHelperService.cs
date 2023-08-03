

namespace VelvetLeaves.Services.Contracts
{
    public interface IHelperService
    {
        public Task<string> Currency();

        public Task<string> FavoriteColor();
        public Task<string> FavoriteIcon();
    }
}
