using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IGalleryService _galleryService;

		public HomeController(IGalleryService galleryService)
		{
            _galleryService = galleryService;
		}
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _galleryService.AllGalleriesAsync();
                return View(model);
                
            }
            catch (Exception)
            {
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
