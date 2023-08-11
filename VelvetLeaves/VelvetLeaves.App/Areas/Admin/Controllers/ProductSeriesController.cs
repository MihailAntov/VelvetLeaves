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
		
		private readonly IProductSeriesService _productSeriesService;
		private readonly ILogger<ProductSeriesController> _logger;

		public ProductSeriesController
			(
            IProductSeriesService productSeriesService, ILogger<ProductSeriesController> logger)
        {
            
            _productSeriesService = productSeriesService;
			_logger = logger;
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
            catch (Exception e)
            {
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
            }
			
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductSeriesFormViewModel model)
		{
			try
			{

				if (!ModelState.IsValid)
            {
				model = await _productSeriesService.PopulateModel(model);
				return View(model);
			}

			
				await _productSeriesService.AddAsync(model);
				return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}");
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
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
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
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
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}

			
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int productSeriesId, ProductSeriesFormViewModel model)
		{
			try
			{

				if (!ModelState.IsValid)
			{
				model = await _productSeriesService.PopulateModel(model);
				return View(model);
			}


			
				await _productSeriesService.EditAsync(productSeriesId, model);
				return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}");
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
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
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}

			
		}
	}
}
