

using VelvetLeaves.Service.Models;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductsFilteredAndPagedServiceModel> ProductsFilteredAndPagedAsync(ProductsQueryModel model);

        Task<ProductDetailsViewModel> DetailsByIdAsync(int id);

        Task<bool> ExistsByIdAsync(int id);
        
    }
}
