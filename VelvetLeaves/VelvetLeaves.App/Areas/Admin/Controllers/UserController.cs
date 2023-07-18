using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> MakeAdmin()
        {
            if(!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            return Redirect("Admin/Controllers/Index");
        }
    }
}
