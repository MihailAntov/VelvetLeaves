using VelvetLeaves.ViewModels.Colors;

namespace VelvetLeaves.Services.Contracts
{
    public interface  IColorService
    {
        Task<IEnumerable<ColorSelectViewModel>> GetColorOptionsAsync(int? categoryId, int? subcategoryId);
        Task<IEnumerable<ColorSelectViewModel>> GetAllColorsAsync();

        Task AddAsync(ColorFormViewModel model);

        Task DeleteAsync(int colorId);
        Task<bool> ExistsByIdAsync(int colorId);    

    }
}
