using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VelvetLeaves.Service.Models;
using VelvetLeaves.Services;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Web.App.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(
            IProductService productService,
            ILogger<ProductsController> logger
            )
        {
            _productService = productService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ProductsFiltered(ProductsQueryModel queryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                queryModel = await _productService.ProductsFilteredAndPagedAsync(queryModel);
                return View("Products", queryModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var model = await _productService.DetailsByIdAsync(id);
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown at {Time}", DateTime.UtcNow);
                return NotFound();
            }
        } 
    }
}
