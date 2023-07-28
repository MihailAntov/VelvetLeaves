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

        [HttpPost]
        public async Task MoveLeft(int productId, int galleryId)
        {
            if(!await _galleryService.ProductInGallery(productId, galleryId))
            {
                return;
            }

            await _galleryService.MoveLeft(productId, galleryId);


        }

        [HttpPost]
        public async Task MoveRight(int productId, int galleryId)
        {
            if (!await _galleryService.ProductInGallery(productId, galleryId))
            {
                return;
            }

            await _galleryService.MoveRight(productId, galleryId);
        }

        [HttpPost]
        public async Task Delete(int productId, int galleryId)
        {
            if (!await _galleryService.ProductInGallery(productId, galleryId))
            {
                return;
            }

            await _galleryService.Delete(productId, galleryId);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int galleryId)
        {
            var model = await _galleryService.GetGalleryByIdAsync(galleryId);
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
        [HttpGet]
        public async Task<IActionResult> AddItem(int galleryId)
        {
            var model = await _galleryService.GetItemsToAddAsync(galleryId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddToGalleryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return LocalRedirect($"~/Admin/Galleries/Edit?galleryId={model.GalleryId}");
            
        }
    }
}
