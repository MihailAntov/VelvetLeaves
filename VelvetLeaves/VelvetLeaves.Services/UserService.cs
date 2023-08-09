

using Microsoft.AspNetCore.Identity;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.User;

using static VelvetLeaves.Common.ApplicationConstants;
namespace VelvetLeaves.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task MakeAdminAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, AdminRoleName);
        }

        public async Task MakeModeratorAsync(string userId)
        {
            if (!await _roleManager.RoleExistsAsync(ModeratorRoleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(ModeratorRoleName));
            }

            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, ModeratorRoleName);
        }

        public async Task<IEnumerable<UserPromoteViewModel>> GetFormForPromoteAsync(string currentUserId)
        {
            
            var model = _userManager.Users
                .Where(u => u.Id != currentUserId)
                .Select(u => new UserPromoteViewModel()
                {
                    Email = u.Email,
                    Username = u.UserName,
                    UserId = u.Id,
                }).ToList();

            foreach (var user in model)
            {
                var thisUser = await _userManager.FindByIdAsync(user.UserId);
                user.IsModerator = await _userManager.IsInRoleAsync(thisUser, "Moderator");
                user.IsAdmin = await _userManager.IsInRoleAsync(thisUser, "Admin");
            }
            return model;
        }

        public async Task RemoveModeratorAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, ModeratorRoleName);
        }
    }
}
