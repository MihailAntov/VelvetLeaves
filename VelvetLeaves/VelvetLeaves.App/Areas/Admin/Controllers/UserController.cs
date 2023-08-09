using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.User;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {

            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> MakeModerator(string userId)
        {
            try
            {
                await _userService.MakeModeratorAsync(userId);
                return RedirectToAction("Promote", "User", new { Area = "Admin" });
            }
            catch
            {
                return NotFound();
            }  
        }

        [HttpGet]
        public async Task<IActionResult> RemoveModerator(string userId)
        {
            try
            {
                await _userService.RemoveModeratorAsync(userId);
                return RedirectToAction("Promote", "User", new { Area = "Admin" });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MakeAdmin(string userId)
        {
            try
            {
                await _userService.MakeAdminAsync(userId);
                return RedirectToAction("Promote", "User", new { Area = "Admin" });
            }
            catch
            {
                return NotFound();
            }

            

        }

        [HttpGet]
        public async Task<IActionResult> Promote()
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var model = await _userService.GetFormForPromoteAsync(userId);
                return View(model);
            }
            catch(Exception)
            {
                return NotFound();
            }
            
            

            
        }
    }
}
