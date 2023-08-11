using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IGalleryService _galleryService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IGalleryService galleryService, ILogger<HomeController> logger)
		{
            _galleryService = galleryService;
            _logger = logger;
		}
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _galleryService.AllGalleriesAsync();
                return View(model);
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            
        }

        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Admin()
        {
            return Redirect("/Admin/Products/All");
        }


    }
}
