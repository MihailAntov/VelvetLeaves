
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.Services.Contracts
{
    public interface ITagService
    {
        Task<IEnumerable<TagListViewModel>> GetTagOptionsAsync(int? categoryId, int? subcategoryId);
        Task<IEnumerable<TagListViewModel>> GetAllTagsAsync();

    }
}
