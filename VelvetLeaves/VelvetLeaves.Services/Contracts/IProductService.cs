

using VelvetLeaves.Service.Models;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> AllProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductViewModel>> AllProductsBySubCategoryAsync(int subcategoryId);

        Task<ProductsFilteredAndPagedServiceModel> ProductsFilteredAndPagedAsync(ProductsQueryModel model);
        Task<IEnumerable<string>> GetMaterialOptionsAsync(int? categoryId, int? subcategoryId);
        
    }
}
