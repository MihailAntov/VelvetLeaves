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
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {

            _userService = userService;
            _logger = logger;   
        }

        [HttpGet]
        public async Task<IActionResult> MakeModerator(string userId)
        {
            try
            {
                await _userService.MakeModeratorAsync(userId);
                return RedirectToAction("Promote", "User", new { Area = "Admin" });
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
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
            catch(Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
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
            catch(Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
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
            catch(Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            
            

            
        }
    }
}
