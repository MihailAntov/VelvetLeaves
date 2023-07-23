

using VelvetLeaves.Service.Models;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.Colors;

namespace VelvetLeaves.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductsFilteredAndPagedServiceModel> ProductsFilteredAndPagedAsync(ProductsQueryModel model);

        Task<ProductDetailsViewModel> DetailsByIdAsync(int id);

        Task<bool> ExistsByIdAsync(int id);
        
    }
}
