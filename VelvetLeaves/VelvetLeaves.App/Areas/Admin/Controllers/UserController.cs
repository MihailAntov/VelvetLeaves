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
        public UserController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> MakeModerator()
        {
            if (!await _roleManager.RoleExistsAsync(ModeratorRoleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(ModeratorRoleName));
            }

            return Redirect("Admin/ProductsController/Index");
        }
    }
}
