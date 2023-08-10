using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.ProductSeries;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = AdminAndModeratorRoleNames)]
	public class ProductSeriesController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly ISubcategoryService _subcategoryService;
		private readonly IColorService _colorService;
		private readonly IMaterialService _materialService;
		private readonly ITagService _tagService;
		private readonly IProductSeriesService _productSeriesService;

        public ProductSeriesController
			(ICategoryService categoryService,
            ISubcategoryService subcategoryService,
            IColorService colorService,
            IMaterialService materialService,
            ITagService tagService,
            IProductSeriesService productSeriesService)
        {
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _colorService = colorService;
            _materialService = materialService;
            _tagService = tagService;
            _productSeriesService = productSeriesService;
        }



        [HttpGet]
		public async Task<IActionResult> Add(int categoryId, int subcategoryId)
		{



			var model = new ProductSeriesFormViewModel()
			{
				CategoryId = categoryId,
				SubcategoryId = subcategoryId
			};
            try
            {
				model = await _productSeriesService.PopulateModel(model);
				return View(model);
			}
            catch (Exception)
            {
				return NotFound();
            }
			
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductSeriesFormViewModel model)
		{
            if (!ModelState.IsValid)
            {
				model = await _productSeriesService.PopulateModel(model);
				return View(model);
			}

			try
			{
				await _productSeriesService.AddAsync(model);
				return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}");
			}
			catch (Exception)
			{
				return NotFound();
			}

			
		}

        [HttpGet]
		public async Task<IActionResult> FetchProductSeries(int subcategoryId)
        {
			try
			{
				var model = await _productSeriesService.ProductSeriesBySubcategoryIdAsync(subcategoryId);
				return Json(model);
			}
			catch (Exception)
			{
				return NotFound();
			}

			
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int productSeriesId)
		{
			try
			{
				var model = await _productSeriesService.GetProductSeriesByIdAsync(productSeriesId);
				ViewData["id"] = productSeriesId;
				return View(model);
			}
			catch (Exception)
			{
				return NotFound();
			}

			
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int productSeriesId, ProductSeriesFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model = await _productSeriesService.PopulateModel(model);
				return View(model);
			}


			try
			{
				await _productSeriesService.EditAsync(productSeriesId, model);
				return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}");
			}
			catch (Exception)
			{
				return NotFound();
			}
			
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int productSeriesId, int subcategoryId, int categoryId)
		{
			try
			{
				await _productSeriesService.DeleteAsync(productSeriesId);
				return LocalRedirect($"~/Admin/Products/All?categoryId={categoryId}&subcategoryId={subcategoryId}");
			}
			catch (Exception)
			{
				return NotFound();
			}

			
		}
	}
}
