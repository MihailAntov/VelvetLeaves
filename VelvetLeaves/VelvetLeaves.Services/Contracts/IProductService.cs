

using VelvetLeaves.Service.Models;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.Colors;

namespace VelvetLeaves.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductsFilteredAndPagedServiceModel> ProductsFilteredAndPagedAsync(ProductsQueryModel model);

        public Task<ProductTreeViewModel> GetProductTreeAsync(int? categoryId, int? subcategoryId, int? productSeriesId);

        Task<ProductDetailsViewModel> DetailsByIdAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        
        
    }
}
