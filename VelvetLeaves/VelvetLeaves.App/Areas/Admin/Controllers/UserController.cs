using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VelvetLeaves.Data.Models;
using VelvetLeaves.ViewModels.User;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
;
        }

        public async Task<IActionResult> MakeModerator(string userId)
        {
            if (!await _roleManager.RoleExistsAsync(ModeratorRoleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(ModeratorRoleName));
            }

            try
            {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, ModeratorRoleName);

            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction("Promote", "User", new { Area = "Admin" });
        }

        public async Task<IActionResult> RemoveModerator(string userId)
        {
            

            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                await _userManager.RemoveFromRoleAsync(user, ModeratorRoleName);

            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction("Promote", "User", new { Area = "Admin" });
        }

        public async Task<IActionResult> MakeAdmin(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                await _userManager.AddToRoleAsync(user, AdminRoleName);
            }
            catch
            {
                return BadRequest();
            }

            

            return RedirectToAction("Promote", "User", new { Area = "Admin" });
        }

        public async Task<IActionResult> Promote()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _userManager.Users
                .Where(u=> u.Id != userId)
                .Select(u => new UserPromoteViewModel()
                {
                    Email = u.Email,
                    Username = u.UserName,
                    UserId = u.Id,
                }).ToList();

            foreach(var user in model)
            {
                var thisUser = await _userManager.FindByIdAsync(user.UserId);
                user.IsModerator = await _userManager.IsInRoleAsync(thisUser, "Moderator");
                user.IsAdmin = await _userManager.IsInRoleAsync(thisUser, "Admin");
            }

            return View(model);

            
        }
    }
}
