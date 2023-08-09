

using VelvetLeaves.ViewModels.User;

namespace VelvetLeaves.Services.Contracts
{
    public interface IUserService
    {
        Task MakeModeratorAsync(string userId);

        Task RemoveModeratorAsync(string userId);

        Task MakeAdminAsync(string userId);

        Task<IEnumerable<UserPromoteViewModel>> GetFormForPromoteAsync(string currentUserId);
    }
}
