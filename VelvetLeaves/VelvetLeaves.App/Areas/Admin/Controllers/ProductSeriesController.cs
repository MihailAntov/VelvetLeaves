using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Moderator")]
	public class ProductSeriesController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Add(int subcategoryId)
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductSeriesFormViewModel model)
		{
			throw new NotImplementedException();
		}
	}
}
