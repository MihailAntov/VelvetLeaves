
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Services.Contracts
{
    public interface IFavoriteService
    {
        Task<ICollection<ProductListViewModel>> GetFavoritesByUserIdAsync(string userId);

        Task AddToFavorites(string userId, int productId);

        Task RemoveFromFavorites(string userId, int productId);

        Task<bool> IsFavorited(string userId, int productId);
    }
}
