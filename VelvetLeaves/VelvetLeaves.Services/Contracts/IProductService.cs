

using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> AllProductsByCategory(int categoryId);
        
    }
}
