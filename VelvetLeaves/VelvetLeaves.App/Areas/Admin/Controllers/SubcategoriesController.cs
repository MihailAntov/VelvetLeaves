﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Subcategory;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = AdminAndModeratorRoleNames)]
	public class SubcategoriesController : Controller
	{
		private readonly IImageService _imageService;
		private readonly ISubcategoryService _subcategoryService;
		private readonly ICategoryService _categoryService;
		private readonly ILogger<SubcategoriesController> _logger;
		public SubcategoriesController(IImageService imageService, ISubcategoryService subcategoryService, ICategoryService categoryService, ILogger<SubcategoriesController> logger)
		{
			_imageService = imageService;
			_subcategoryService = subcategoryService;
			_categoryService = categoryService;	
			_logger = logger;	
		}

		[HttpGet]
		public async Task<IActionResult> Add(int categoryId)
		{


			var model = new SubcategoryFormViewModel()
			{
				CategoryId = categoryId
			};

            try
            {
				model = await _subcategoryService.PopulateModel(model);
				return View(model);
			}
            catch(Exception e)
            {
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
            }
		}

		[HttpPost]
		public async Task<IActionResult> Add(SubcategoryFormViewModel model)
		{
			try
			{

				if (!ModelState.IsValid)
			{
				model.CategoryOptions = await _categoryService.AllCategoriesAsync();
				return View(model);
			}

            
				string? imageId = await _imageService.CreateAsync(model.Image);

				if (imageId == null)
				{
					ModelState.AddModelError("Image", "Image upload unsuccessful.");
				}

				await _subcategoryService.AddAsync(model.Name, model.CategoryId, imageId!);


				return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}");
			}
            catch (Exception e)
            {
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}

			
		}

        [HttpGet]
		public async Task<IActionResult> FetchSubcategories(int categoryId)
        {
			try
			{
				var model = await _subcategoryService.SubcategoriesByCategoryIdAsync(categoryId);
				return Json(model);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}

			
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int subcategoryId)
		{
			try
			{
				var model = await _subcategoryService.GetForEditAsync(subcategoryId);
				return View(model);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}

			
		}

		[HttpPost]
		public async Task<IActionResult> Edit(SubcategoryEditFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await _subcategoryService.EditAsync(model);
				return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}");
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}

			
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int subcategoryId, int categoryId)
		{
			try
			{
				await _subcategoryService.DeleteAsync(subcategoryId);
				return LocalRedirect($"~/Admin/Products/All?categoryId={categoryId}");
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}
			
		}
	}
}
