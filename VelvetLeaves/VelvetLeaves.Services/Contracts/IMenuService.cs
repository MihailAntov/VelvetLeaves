using VelvetLeaves.ViewModels.Menu;

namespace VelvetLeaves.Services.Contracts
{
    public interface IMenuService
    {
        Task<IEnumerable<CategoryMenuViewModel>> GetMenuCategoriesAsync();
    }
}
