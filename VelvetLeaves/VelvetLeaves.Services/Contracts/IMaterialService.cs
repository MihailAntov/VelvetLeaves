
using VelvetLeaves.ViewModels.Material;

namespace VelvetLeaves.Services.Contracts
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialListViewModel>> GetMaterialOptionsAsync(int? categoryId, int? subcategoryId);
        Task<IEnumerable<MaterialListViewModel>> GetAllMaterialsAsync();

        Task AddAsync(MaterialFormViewModel model);

        Task DeleteAsync(int materialId);

    }
}
