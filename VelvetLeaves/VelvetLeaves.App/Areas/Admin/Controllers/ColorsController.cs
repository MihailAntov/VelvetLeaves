﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Colors;
using static VelvetLeaves.Common.ApplicationConstants;


namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = $"{AdminRoleName},${ModeratorRoleName}")]
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

			await _colorService.AddAsync(model);

			return RedirectToAction("All", "Products");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int colorId)
		{
			await _colorService.DeleteAsync(colorId);
			return RedirectToAction("All", "Products");

		}
	}
}
