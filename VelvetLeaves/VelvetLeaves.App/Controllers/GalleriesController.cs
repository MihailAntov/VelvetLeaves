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
        private readonly ILogger<GalleriesController> _logger;
        public GalleriesController(IGalleryService galleryService, ILogger<GalleriesController> logger)
        {
            this.galleryService = galleryService;
            _logger = logger;
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
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            try
            {
                var galleries = await galleryService.AllGalleriesAsync();
                return View(galleries);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }
        }

        
    }
}
