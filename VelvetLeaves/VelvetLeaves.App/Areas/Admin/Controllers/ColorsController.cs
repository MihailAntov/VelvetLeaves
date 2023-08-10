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
        public ColorsController(IColorService colorService)
        {
			_colorService = colorService;
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
            catch (Exception)
            {
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
			catch (Exception)
			{
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
            catch (Exception)
            {
				return NotFound();
            }
			
			

		}
	}
}
