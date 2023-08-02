using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Address;

namespace VelvetLeaves.App.Controllers
{
	[Authorize]
	public class AddressesController : Controller
	{

		private readonly IAddressService _addressService;
		public AddressesController(IAddressService addressService)
		{
			_addressService = addressService;
		}
		public async Task<IActionResult> All()
		{
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var model = await _addressService.GetAddressOptionsAsync(userId);
			return View(model);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddressFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			await _addressService.AddAsync(model, userId);
			return RedirectToAction("All");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			var model = await _addressService.GetAddressByIdAsync(id);
			
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, AddressFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _addressService.UpdateAsync(id, model);

			return RedirectToAction("All", "Addresses");
		}

		public async Task<IActionResult> FetchAddress(string addressId)
		{
			var model = await _addressService.GetAddressByIdAsync(addressId);
			
			return PartialView("_AddressForm", model);
		}


	}
}
