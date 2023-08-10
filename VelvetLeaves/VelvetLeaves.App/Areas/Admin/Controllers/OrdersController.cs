using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Common.Enums;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Order;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = AdminAndModeratorRoleNames)]
	public class OrdersController : Controller
	{

		private readonly IOrderService _orderService;
		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpGet]
		public async Task<IActionResult> All(OrderStatus status = OrderStatus.Pending)
		{
            try
            {
				var model = await _orderService.AllAsync(status);
				return View(model);
			}
            catch(Exception)
            {
				return NotFound();
            }
			
		}
		
		[HttpGet]
		public async Task<IActionResult> Details(string orderId)
		{
            try
            {
				var model = await _orderService.DetailsAsync(orderId);
				return View(model);
			}
            catch (Exception)
            {
				return NotFound();
            }
			
		}

        [HttpGet]
		public async Task<IActionResult> Process (string orderId, OrderStatus status)
        {
            try
            {
				await _orderService.ChangeStatusAsync(orderId, status);
				return RedirectToAction("All", "Orders", new { Area = "Admin" });
			}
            catch (Exception)
            {
				return NotFound();
            }
			
			
        }

        [HttpGet]
		public async Task<IActionResult> FetchOrders(OrderStatus status)
        {
            try
            {
				var model = await _orderService.AllAsync(status);
				return PartialView("_OrderList", model);
            }
            catch (Exception)
            {
				return NotFound();
            }
        }

        [HttpPost]
		public async Task<IActionResult> AddAdminNote(string note, string orderId)
        {
            try
            {
				var result = await _orderService.AddAdminNoteAsync(note, orderId);
				return Json(result);
			}
            catch
            {
				return NotFound();
            }
			
        }

	

	
	}
}
