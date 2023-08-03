using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Data.Models;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> MakeModerator()
        {
            if (!await _roleManager.RoleExistsAsync(ModeratorRoleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(ModeratorRoleName));
            }

            return Redirect("Admin/ProductsController/Index");
        }

        public async Task<IActionResult> Promote()
        {
            var model = _userManager.Users.Select(u=> new UserPromoteViewModel()
            {

            })
        }
    }
}
