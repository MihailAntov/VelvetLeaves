using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Gallery;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = $"{AdminRoleName},${ModeratorRoleName}")]
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


        /// <summary>
        /// Deletes a GalleryProduct item from the gallery
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="galleryId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Delete(int productId, int galleryId)
        {
            if (!await _galleryService.ProductInGallery(productId, galleryId))
            {
                return;
            }

            await _galleryService.DeleteItem(productId, galleryId);
        }

		[HttpGet]
        public async Task<IActionResult> Edit(int galleryId)
		{
            try
            {

            var model = await _galleryService.GetGalleryEditFormAsync(galleryId);

            return View(model);

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GalleryEditFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
                return View(model);
			}
            if(model.Image != null)
            {
                await _imageService.UpdateAsync(model.ImageId, model.Image);

            }

            await _galleryService.EditAsync(model);

            return RedirectToAction("All", "Galleries");


		}

        [HttpGet]
        public async Task<IActionResult> Show(int galleryId)
        {
            try
            {

            var model = await _galleryService.GetGalleryByIdAsync(galleryId);
            return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
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
            try
            {

            var model = await _galleryService.GetItemsToAddAsync(galleryId);
            return View(model);
            
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddToGalleryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _galleryService.AddItemsToGalleryAsync(model.GalleryId, model.ProductIds);

            return LocalRedirect($"~/Admin/Galleries/Show?galleryId={model.GalleryId}");
            
        }

		[HttpGet]
        public async Task<IActionResult> Delete(int galleryId)
		{
            try
            {
            await _galleryService.DeleteAsync(galleryId);

            }
            catch(Exception)
            {
                return NotFound();
            }
            
            
            return RedirectToAction("All", "Galleries");
        }
    }
}
