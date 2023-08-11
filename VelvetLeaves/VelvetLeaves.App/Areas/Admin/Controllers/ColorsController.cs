using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Colors;
using static VelvetLeaves.Common.ApplicationConstants;


namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = AdminAndModeratorRoleNames)]
	public class ColorsController : Controller
	{
		private readonly IColorService _colorService;
		private readonly ILogger<ColorsController> _logger;
		public ColorsController(IColorService colorService, ILogger<ColorsController> logger)
        {
			_colorService = colorService;
			_logger = logger;
        }
		
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(ColorFormViewModel model)
		{
            if (!ModelState.IsValid)
            {
				return View(model);
            }

            try
            {
				await _colorService.AddAsync(model);
				return RedirectToAction("All", "Colors");
			}
            catch (Exception e)
            {
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
            }
			
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			try
			{
				var model = await _colorService.GetAllColorsAsync();
				return View(model);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int colorId)
		{
            try
            {
				await _colorService.DeleteAsync(colorId);
				return RedirectToAction("All", "Colors");
			}
            catch (Exception e)
            {
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
            }
			
			

		}
	}
}
