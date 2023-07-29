using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.Services.Contracts
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategorySelectViewModel>> AllCategoriesAsync();
        

        public Task AddCategoryAsync(string categoryName, string url);
        public Task<int> GetDefaultCategoryIdAsync();

        public Task<CategoryEditFormViewModel> GetForEditAsync(int categoryId);
        public Task EditAsync(CategoryEditFormViewModel model);

        public Task DeleteAsync(int categoryId);
    }
}
