using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Gallery;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Moderator, Admin")]
    public class GalleriesController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IGalleryService _galleryService;

        public GalleriesController(IImageService imageService, IGalleryService galleryService)
        {
            _imageService = imageService;
            _galleryService = galleryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await _galleryService.AllGalleriesAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(GalleryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string? imageId = await _imageService.CreateAsync(model.Image);
            if(imageId == null)
            {
                ModelState.AddModelError("Image", "Image upload unsuccessful.");
                return View(model);
            }
            model.ImageId = imageId;

            await _galleryService.AddAsync(model);

            return RedirectToAction("All", "Galleries");
        }
    }
}
