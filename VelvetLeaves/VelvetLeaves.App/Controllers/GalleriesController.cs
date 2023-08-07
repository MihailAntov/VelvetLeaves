using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using static VelvetLeaves.Web.Infrastructure.Extensions.ClaimsPrincipalExtensions;

namespace VelvetLeaves.Web.App.Controllers
{
    [Authorize]
    public class GalleriesController : Controller
    {
        private readonly IGalleryService galleryService;
        public GalleriesController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            try
            {
            var gallery = await galleryService.GetGalleryByIdAsync(id);
            return View(gallery);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var galleries = await galleryService.AllGalleriesAsync();
            return View(galleries);
        }

        
    }
}
