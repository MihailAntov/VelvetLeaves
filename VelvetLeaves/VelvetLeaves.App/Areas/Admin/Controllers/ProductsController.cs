using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.ProductSeries;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.Web.App.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = $"{AdminRoleName},{ModeratorRoleName}")]

    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductSeriesService _productSeriesService;
        private readonly IImageService _imageService;
        public ProductsController(
            IProductService productService,
            IProductSeriesService productSeriesService,
            IImageService imageService)
        {
            _productService = productService;
            _productSeriesService = productSeriesService;
            _imageService = imageService;
        }
        /// <summary>
        /// Returns all products, grouped by product series, then by subcategory, then by category, to be browsed in a tree-like structure.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All(int? categoryId, int? subcategoryId, int? productSeriesId)
        {
            try
            {
                var model = await _productService.GetProductTreeAsync(categoryId, subcategoryId, productSeriesId);
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int productId)
        {
            try
            {
                var model = await _productService.GetFormForEditAsync(productId);
                return View(model);

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ImageIds = model.StartingImageIds!.ToList();
                return View(model);
            }

            try
            {
                await _productService.UpdateAsync(model);
                return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}&productSeriesId={model.ProductSeriesId}");

            }
            catch
            {
                return NotFound();
            }



            //return RedirectToAction("All", "Products");


        }

        [HttpGet]
        public async Task<IActionResult> Add(int categoryId, int subcategoryId, int productSeriesId)
        {
            try
            {
                var model = await _productService.GetFormForAddAsync(categoryId, subcategoryId, productSeriesId);
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }


        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
            {
                var newOptions = await _productService.GetFormForAddAsync(model.CategoryId, model.SubcategoryId, model.ProductSeriesId);
                model.CategoryOptions = newOptions.CategoryOptions;
                model.SubcategoryOptions = newOptions.SubcategoryOptions;
                model.ProductSeriesOptions = newOptions.ProductSeriesOptions;
                model.MaterialOptions = newOptions.MaterialOptions;
                model.TagOptions = newOptions.TagOptions;
                model.ColorOptions = newOptions.ColorOptions;

                return View(model);
            }
            
                var imageIds = await _imageService.CreateRangeAsync(model.Images);
                if (imageIds.Any(id => id == null))
                {
                    ModelState.AddModelError("Image", "Image upload unsuccessful.");
                    return View(model);
                }

                model.ImageIds = imageIds!;

                await _productService.AddAsync(model);
                return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}&productSeriesId={model.ProductSeriesId}");

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> FetchDefaultValues(int productSeriesId)
        {
            try
            {
                var model = await _productSeriesService.GetDefaultValues(productSeriesId);
                return Json(model);
            }
            catch (Exception)
            {
                return NotFound();
            }


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int productId, int categoryId, int subcategoryId, int productSeriesId)
        {
            try
            {
                await _productService.DeleteAsync(productId);
                return LocalRedirect($"~/Admin/Products/All?categoryId={categoryId}&subcategoryId={subcategoryId}&productSeriesId={productSeriesId}");

            }
            catch (Exception)
            {
                return NotFound();
            }


        }
    }
}

