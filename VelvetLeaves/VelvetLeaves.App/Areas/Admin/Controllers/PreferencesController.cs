﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.AppPreferences;
using static VelvetLeaves.Common.ApplicationConstants;


namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminAndModeratorRoleNames)]
    public class PreferencesController : Controller
    {
        private readonly IHelperService _helperService;
        private readonly IImageService _imageService;
        public PreferencesController(IHelperService helperService, IImageService imageService)
        {
            _helperService = helperService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Set()
        {
            try
            {
                var model = await _helperService.GetCurrentPreferences();
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Set(AppPreferencesFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                if (model.Image != null)
                {
                    var backgroundImageId = await _imageService.CreateAsync(model.Image);
                    if (backgroundImageId == null)
                    {
                        ModelState.AddModelError("image", "Image upload unsuccessful.");
                        return View(model);
                    }
                    model.ImageId = backgroundImageId!;
                }


                await _helperService.SetCurrentPreferences(model);
                return RedirectToAction("All", "Products", new { Area = "Admin" });

            }
            catch (Exception)
            {
                return NotFound();
            }


        }
    }
}
