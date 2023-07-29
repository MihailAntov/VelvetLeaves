﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.Web.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IProductSeriesService _productSeriesService;
        private readonly IColorService _colorService;
        private readonly IMaterialService _materialService;
        private readonly ITagService _tagService;
        private readonly IImageService _imageService;
        public ProductsController(
            IProductService productService,
            ICategoryService categoryService,
            ISubcategoryService subcategoryService,
            IProductSeriesService productSeriesService,
            IColorService colorService,
            IMaterialService materialService,
            ITagService tagService,
            IImageService imageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _productSeriesService = productSeriesService;
            _colorService = colorService;
            _materialService = materialService;
            _tagService = tagService;
            _imageService = imageService;   
        }
        /// <summary>
        /// Returns all products, grouped by product series, then by subcategory, then by category, to be browsed in a tree-like structure.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All(int? categoryId, int? subcategoryId, int? productSeriesId)
        {
            var model = await _productService.GetProductTreeAsync(categoryId, subcategoryId, productSeriesId);
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int productId)
        {
            var model = await _productService.GetFormForEditAsync(productId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            await _productService.UpdateAsync(model);


            //return RedirectToAction("All", "Products");
			return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}&productSeriesId={model.ProductSeriesId}");


		}

        [HttpGet]
        public async Task<IActionResult> Add(int categoryId, int subcategoryId, int productSeriesId)
        {
            var model = await _productService.GetFormForAddAsync(categoryId, subcategoryId, productSeriesId);

            return View(model);

        }

        [HttpPost]
        public  async Task<IActionResult> Add(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var imageIds = await _imageService.CreateRangeAsync(model.Images);
            if(imageIds.Any(id=> id == null))
            {
                ModelState.AddModelError("Image", "Image upload unsuccessful.");
                return View(model);
            }

            model.ImageIds = imageIds!;
            await _productService.AddAsync(model);

            return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}&productSeriesId={model.ProductSeriesId}");
        }

        [HttpGet]
        public async Task<IActionResult> FetchDefaultValues(int productSeriesId)
        {
            var model = await _productSeriesService.GetDefaultValues(productSeriesId);
            return Json(model);
        }

		[HttpGet]
        public async Task<IActionResult> Delete(int productId, int categoryId, int subcategoryId, int productSeriesId)
		{
            await _productService.DeleteAsync(productId);

            return LocalRedirect($"~/Admin/Products/All?categoryId={categoryId}&subcategoryId={subcategoryId}&productSeriesId={productSeriesId}");

        }
    }
}
