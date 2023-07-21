
namespace VelvetLeaves.Services.Contracts
{
    public interface ITagService
    {
        Task<IEnumerable<string>> GetTagOptionsAsync(int? categoryId, int? subcategoryId);

    }
}
