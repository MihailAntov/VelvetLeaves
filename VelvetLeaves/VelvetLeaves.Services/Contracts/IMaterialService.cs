
namespace VelvetLeaves.Services.Contracts
{
    public interface IMaterialService
    {
        Task<IEnumerable<string>> GetMaterialOptionsAsync(int? categoryId, int? subcategoryId);

    }
}
