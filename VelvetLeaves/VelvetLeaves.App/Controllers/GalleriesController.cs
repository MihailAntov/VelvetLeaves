using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.App.Controllers
{
    public class GalleriesController : Controller
    {
        private readonly IGalleryService galleryService;
		public GalleriesController(IGalleryService galleryService)
		{
            this.galleryService = galleryService;
		}
		[HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            var gallery = await galleryService.GetGalleryByIdAsync(id);
            if(gallery == null)
			{
                return NotFound();
			}
            return View(gallery);
        }

        public async Task<IActionResult> All()
		{
            var galleries = await galleryService.AllGalleriesAsync();
            return View(galleries);
		}

        public async Task<IActionResult> Featured()
		{
            var featuredGallery = await galleryService.GetGalleryByIdAsync(1);
            if (featuredGallery == null)
            {
                return NotFound();
            }
            return View("Show",featuredGallery);
        }
    }
}
