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
        private readonly ILogger<AddressesController> _logger;
        public AddressesController(IAddressService addressService, ILogger<AddressesController> logger)
        {
            _addressService = addressService;
            _logger = logger;
        }
        public async Task<IActionResult> All()
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var model = await _addressService.GetAddressOptionsAsync(userId);
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            
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
            try
            {
                await _addressService.AddAsync(model, userId);
                return RedirectToAction("All");

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _addressService.GetAddressByIdAsync(id);
                return View(model);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddressFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                await _addressService.UpdateAsync(id, model);
                return RedirectToAction("All", "Addresses");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }

        }


        public async Task<IActionResult> FetchAddress(string addressId)
        {
            try
            {
                var model = await _addressService.GetAddressByIdAsync(addressId);
                return PartialView("_AddressForm", model);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }

        }

		[HttpGet]
        public async Task<IActionResult> Delete(string addressId)
		{
			try
			{
                await _addressService.DeleteAsync(addressId);
                return RedirectToAction("All", "Addresses");
			}
			catch (Exception e)
			{
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
			}
		}

        private IActionResult AddGeneralError()
        {
            TempData["ErrorMessage"] = "Unexpected error. Please try again later.";
            return RedirectToAction("Index", "Home");
        }


    }
}
