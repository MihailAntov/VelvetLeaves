using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.Services.Contracts
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryListViewModel>> AllCategoriesAsync();
    }
}
