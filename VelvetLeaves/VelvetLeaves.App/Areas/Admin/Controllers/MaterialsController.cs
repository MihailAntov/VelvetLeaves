﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Material;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = $"{AdminRoleName},${ModeratorRoleName}")]
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

		[HttpPost]
		public async Task<IActionResult> Add(MaterialFormViewModel model)
		{
            if (!ModelState.IsValid)
            {
				return View(model);
            }

			await _materialService.AddAsync(model);

			return RedirectToAction("All", "Products");
		}

		[HttpPost]
		public async Task<IActionResult> Remove(int materialId)
		{
			await _materialService.DeleteAsync(materialId);
			return RedirectToAction("All", "Products");
		}
	}
}
