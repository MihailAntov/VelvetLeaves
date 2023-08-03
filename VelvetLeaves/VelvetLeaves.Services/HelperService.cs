

using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
    public class HelperService : IHelperService
    {
        public async Task<string> Currency()
        {
            return "лв.";
        }

        public async Task<string> FavoriteColor()
        {
            return "gold";
        }

        public async Task<string> FavoriteIcon()
        {
            return "star";
        }
    }
}
