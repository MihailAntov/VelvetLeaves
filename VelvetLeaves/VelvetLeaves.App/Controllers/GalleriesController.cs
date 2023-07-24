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
            var gallery = await galleryService.GetGalleryByIdAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(gallery);
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var galleries = await galleryService.AllGalleriesAsync();
            return View(galleries);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Featured()
        {
            //TODO replace 1 with app preferences variable

            var featuredGallery = await galleryService.GetGalleryByIdAsync(1);
            if (featuredGallery == null)
            {
                return NotFound();
            }
            return View("Show", featuredGallery);
        }
    }
}
