using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Material;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	//[Authorize(Roles = AdminAndModeratorRoleNames)]
	[Authorize(Roles = "Admin,Moderator")]
	public class MaterialsController : Controller
	{
		private readonly IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
			_materialService = materialService;
        }

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			try
			{
				var model = await _materialService.GetAllMaterialsAsync();
				return View(model);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Add(MaterialFormViewModel model)
		{
            if (!ModelState.IsValid)
            {
				return View(model);
            }

            try
            {
				await _materialService.AddAsync(model);
				return RedirectToAction("All", "Products");
			}
            catch (Exception)
            {
				return NotFound();
			}

			
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int materialId)
		{
            try
            {
				await _materialService.DeleteAsync(materialId);
				return RedirectToAction("All", "Materials");
            }
            catch (Exception)
            {
				return NotFound();
            }
		}
	}
}
