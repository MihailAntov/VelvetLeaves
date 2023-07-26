using VelvetLeaves.ViewModels.Colors;

namespace VelvetLeaves.Services.Contracts
{
    public interface  IColorService
    {
        Task<IEnumerable<ColorSelectViewModel>> GetColorOptionsAsync(int? categoryId, int? subcategoryId);
        Task<IEnumerable<ColorSelectViewModel>> GetAllColorsAsync();

    }
}
