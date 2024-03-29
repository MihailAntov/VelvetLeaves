﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Tag;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = AdminAndModeratorRoleNames)]
	public class TagsController : Controller
	{

		private readonly ITagService _tagService;
		private readonly ILogger<TagsController> _logger;
		public TagsController(ITagService tagService, ILogger<TagsController> logger)
        {
            _tagService = tagService;
			_logger = logger;
        }

        [HttpGet]
		public  IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(TagFormViewModel model)
		{
            if (!ModelState.IsValid)
            {
				return View(model);
            }

            try
            {
				await _tagService.AddAsync(model);
				return RedirectToAction("All", "Tags");
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
				var model = await _tagService.GetAllTagsAsync();
				return View(model);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int tagId)
		{
            try
            {
				await _tagService.DeleteAsync(tagId);
				return RedirectToAction("All", "Tags");
			}
            catch (Exception e)
            {
				_logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
				return NotFound();
            }
			
			
		}
	}
}
