using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Moderator")]
	public class TagsController : Controller
	{

		private readonly ITagService _tagService;
        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
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
			
			await _tagService.AddAsync(model);

			return RedirectToAction("All", "Products");
		}
	}
}
