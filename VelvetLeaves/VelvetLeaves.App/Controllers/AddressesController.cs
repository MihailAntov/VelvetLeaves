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
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var model = await _addressService.GetAddressOptionsAsync(userId);
                return View(model);
            }
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
