

using VelvetLeaves.Service.Models;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.Service.Models.ShoppingCart;

namespace VelvetLeaves.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductsFilteredAndPagedServiceModel> ProductsFilteredAndPagedAsync(ProductsQueryModel model);

        public Task<ProductTreeViewModel> GetProductTreeAsync(int? categoryId, int? subcategoryId, int? productSeriesId);

        Task<ProductDetailsViewModel> DetailsByIdAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        Task AddAsync(ProductFormViewModel model);

        Task<ProductFormViewModel> GetFormForAddAsync(int categoryId, int subcategoryId, int productSeriesId);

        Task<ProductEditFormViewModel> GetFormForEditAsync(int productId);

        Task UpdateAsync(ProductEditFormViewModel model);

        Task DeleteAsync(int productId);

        Task<IEnumerable<ProductForCartDto>> GetProductsForCart(IEnumerable<int> productIds);

        Task<bool> ProductExistsAsync(int productId);

        Task<ICollection<ProductListViewModel>> GetFavoritesByUserIdAsync(string userId);

        Task AddToFavorites(string userId, int productId);

        Task RemoveFromFavorites(string userId, int productId);



    }
}
